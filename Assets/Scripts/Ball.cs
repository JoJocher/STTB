using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public static readonly List<Ball> s_Balls = new List<Ball>();

    BoxCollider2D m_paddleCollider;
    public float BaseSpeed { get; } = 2.5f;
    float m_fSpeed;
    readonly float m_fMinYDirection = 0.2f;
    Rigidbody2D m_rbBall;
    ContactPoint2D m_contactPoint;
    Vector2 m_v2LinVelocity;

    public bool IsMenu { get; set; }

    void Awake()
    {
        m_fSpeed = BaseSpeed;

        m_paddleCollider = GameObject.FindGameObjectWithTag(ConstantValues.PaddleTag).GetComponent<BoxCollider2D>();

        s_Balls.Add(this);

        m_rbBall = GetComponent<Rigidbody2D>();

        m_v2LinVelocity = m_rbBall.linearVelocity;
    }

    void Start()
    {
        if (!IsMenu)
            SpawnMovement();
    }

    void FixedUpdate()
    {
        //before Unity does the collision resolving, store the linear velocity
        m_v2LinVelocity = m_rbBall.linearVelocity;
    }

    void SpawnMovement()
    {
        int iRandomAngle = Random.Range(-3, 4) * 10;

        Vector2 v2Direction = Quaternion.Euler(0f, 0f, iRandomAngle) * Vector2.down;
        m_rbBall.linearVelocity = v2Direction * m_fSpeed;
    }

    public void StartMovement()
    {
        m_rbBall.linearVelocity = Vector2.down * m_fSpeed;
    }

    public void StopMovement()
    {
        m_rbBall.linearVelocity = Vector2.zero;
    }

    public void SetSpeed(float _newSpeed)
    {
        m_fSpeed = _newSpeed;
        ApplyMovement(m_rbBall.linearVelocity.normalized);
    }

    void OnCollisionEnter2D(Collision2D _collision)
    {

        if (_collision.gameObject.CompareTag(ConstantValues.BallTag))
            return;
        m_contactPoint = _collision.contacts[0];

        if (_collision.collider != m_paddleCollider)
        {
            Hit();
            return;
        }
        HitPaddle();
    }

    void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.gameObject.CompareTag(ConstantValues.LevelmanagerTag))
            Destroy(gameObject);
    }

    void OnDisable()
    {
        s_Balls.Remove(this);
    }


    Vector2 CalculateHitDirection()
    {
        Vector2 v2Direction = m_v2LinVelocity.normalized;
        Vector2 v2ContactNormal = m_contactPoint.normal;


        if (Vector2.Dot(v2Direction, v2ContactNormal) < 0f)
        {
            Vector2 v2ReflectedDirection = Vector2.Reflect(v2Direction, v2ContactNormal);
            return v2ReflectedDirection;
        }
        return v2Direction;
    }

    void Hit()
    {
        Vector2 v2Direction = CalculateHitDirection();
        
        // Preventing nearly horizontal movement so that the ball does not get stuck
        if (Mathf.Abs(v2Direction.y) < m_fMinYDirection)
        {
            float fYSign;

            if (!Mathf.Approximately(v2Direction.y, 0))
                fYSign = Mathf.Sign(v2Direction.y);
            else
                fYSign = Mathf.Sign(m_contactPoint.normal.y);

            v2Direction.y = fYSign * m_fMinYDirection;
            v2Direction = v2Direction.normalized;
        }
        ApplyMovement(v2Direction);
    }

    void HitPaddle()
    {
        Vector2 v2Direction = CalculateHitDirection();

        //Adjustment of the reflection direction depending on the relative hit position on the paddle
        float fContactX = m_contactPoint.point.x;
        float fPaddleCenterX = m_paddleCollider.bounds.center.x;

        float fHitOffsetFromPaddleCenter = fContactX - fPaddleCenterX;

        float fHalfWidthPaddle = m_paddleCollider.bounds.extents.x;

        float fPaddleHitRelativePosX = fHitOffsetFromPaddleCenter / fHalfWidthPaddle;

        v2Direction.x += fPaddleHitRelativePosX;

        v2Direction = v2Direction.normalized;

        v2Direction.y = Mathf.Max(Mathf.Abs(v2Direction.y), m_fMinYDirection);

        ApplyMovement(v2Direction);
    }

    void ApplyMovement(Vector2 _direction)
    {
        m_rbBall.linearVelocity = _direction * m_fSpeed;
        m_v2LinVelocity = m_rbBall.linearVelocity;
    }
}
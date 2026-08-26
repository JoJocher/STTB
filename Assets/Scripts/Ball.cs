using UnityEngine;
using System.Collections.Generic;
public class Ball : MonoBehaviour
{
    public static List<Ball> balls = new List<Ball>();
    [SerializeField] BoxCollider2D paddleColl;
    /*Ball(int speedMult)
    {
        m_iSpeedMultiplier = speedMult;
    }*/

    public int m_iSpeedMultiplier = 2;
    
    float fContactX;
    float fPaddleCenterX;
    float fHitOffsetFromPaddleCenter;
    float fHalfWidthPaddle;
    float fPaddleHitRelativePosX;
    Vector2 v2DirectionNormalized;
    Rigidbody2D ballRb;

    ContactPoint2D contactPoint;

    Vector2 m_v2LinVelo;

    [SerializeField] public bool m_bIsMenu; //{  get; set; }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        paddleColl = GameObject.FindGameObjectWithTag("paddle").GetComponent<BoxCollider2D>();
        balls.Add(this);
        Debug.Log("Ball Count: " + balls.Count);
        ballRb = this.GetComponent<Rigidbody2D>();

        m_v2LinVelo = new Vector2();

          
       // m_v2LinVelo = ballRb.linearVelocity;

    }

    void Start()
    {
        if (!m_bIsMenu)
            StartMovement();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log(ballRb.linearVelocity);
        m_v2LinVelo = ballRb.linearVelocity;
    }


    public void StartMovement()
    {
        ballRb.linearVelocity = Vector2.down * m_iSpeedMultiplier;
    }
    
    public void StopMovement()
    {
        ballRb.linearVelocity = Vector3.zero;
    }

    public void SetMultiplier(int mult)
    {
        m_iSpeedMultiplier = mult;

    }






    void HitCalculation(Collision2D collision)
    {


        /*linVel = new Vector2(ballRb.linearVelocity.x, ballRb.linearVelocity.y);*/

        contactPoint = collision.contacts[0];


        //normale
       Vector2 p_v2ContactNormal = contactPoint.normal;

        //Reflektion bzw Skalarprodukt

        Vector2 p_v2ReflectedlinVel = new Vector2();

       p_v2ReflectedlinVel = Vector2.Reflect(m_v2LinVelo, p_v2ContactNormal); //ballRb.linearVelocity

        Debug.Log("Reflected " + p_v2ReflectedlinVel);

        //if p_v2ReflectedlinVel 
        ballRb.linearVelocity = p_v2ReflectedlinVel;
        m_v2LinVelo = ballRb.linearVelocity; //speichern für Hits vor dem FixedUpdate
    }

    void PaddleHitCalculation(Collision2D collision)
    {
        contactPoint = collision.contacts[0];
        fContactX = contactPoint.point.x;
        fPaddleCenterX = paddleColl.bounds.center.x;

        fHitOffsetFromPaddleCenter = fContactX - fPaddleCenterX;

        fHalfWidthPaddle = paddleColl.bounds.extents.x;

        fPaddleHitRelativePosX = fHitOffsetFromPaddleCenter / fHalfWidthPaddle;

        v2DirectionNormalized = new Vector2(fPaddleHitRelativePosX, 1f);

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
            return;
        Debug.Log("Contact Point: " + contactPoint.point);
      //  Debug.Log(this.gameObject.name);
       // Debug.Log("Wie viele Kontakte " + collision.contactCount);

      

        if (collision.collider != paddleColl)
        {
            HitCalculation(collision);
            return;
        }
        PaddleHitCalculation(collision);

       
        
  //      Debug.Log(v2DirectionNormalized);
//     float fCurrentSpeed = ballRb.linearVelocity.magnitude;

        ballRb.linearVelocity = v2DirectionNormalized * m_iSpeedMultiplier;
            
          //  v2DirectionNormalized * fCurrentSpeed;

        // Vector2
        

      
        Debug.Log("Paddle Relative Position " + fPaddleHitRelativePosX);

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("levelmanager"))
            Destroy(this.gameObject);    
    }

    void OnDisable()
    {
        Debug.Log("Destroyed ball " + Ball.balls.IndexOf(this));
        Debug.Log("Current ball count " + Ball.balls.Count);
        balls.Remove(this);
        Debug.Log("Remaining Ball Count " + Ball.balls.Count);
    }

}

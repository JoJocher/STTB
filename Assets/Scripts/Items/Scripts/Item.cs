using UnityEngine;

public abstract class Item : MonoBehaviour
{
    Rigidbody2D m_rbItem;

    protected virtual void Awake()
    {
        m_rbItem = GetComponent<Rigidbody2D>();
    }

    protected abstract void ApplyEffect();

    void OnEnable()
    {
        m_rbItem.linearVelocity = Vector2.down;
    }

    void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.gameObject.CompareTag(ConstantValues.PaddleTag))
        {
            ApplyEffect();
            ScoreManager.Instance.AddPoints(PointType.Item);
            Destroy(gameObject);
        }

        else if (_collider.gameObject.CompareTag(ConstantValues.LevelmanagerTag))
            Destroy(gameObject);
    }
}

public abstract class TimedItem : Item
{
    PowerUpManager m_powerUpManager;

    protected virtual void Start()
    {
        m_powerUpManager = GameObject.FindGameObjectWithTag(ConstantValues.LevelmanagerTag).GetComponent<PowerUpManager>();
    }

    protected abstract TimedEffectType EffectType { get; }
    protected abstract float EffectDuration { get; }

    protected override void ApplyEffect()
    {
        ApplyTimedEffect();

        m_powerUpManager.ActivateTimer(EffectType, EffectDuration);
    }

    protected abstract void ApplyTimedEffect();
}

public enum TimedEffectType
{
    SpeedUp,
    PaddleSize
}
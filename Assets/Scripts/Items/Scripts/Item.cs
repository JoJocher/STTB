using UnityEngine;

public abstract class Item : MonoBehaviour
{

    //Transform SpawnPosition;

    /* public Item(Vector2 sp)
      {
          SpawnPosition = sp;

      }
    */
    Rigidbody2D itemRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
   protected virtual void Awake()
    {
        itemRb = this.GetComponent<Rigidbody2D>();
    }
   /*protected void Start()
    {
      //  itemRb.linearVelocity = Vector2.down;

    }*/

    // Update is called once per frame
  

    void DestroyItem()
    {
        Destroy(this.gameObject);
        Debug.Log("Destroyed");
    }

  protected abstract void ApplyEffect();

    void OnEnable()
    {
        itemRb.linearVelocity = Vector2.down;
        Debug.Log("enabled!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision entered");
        if (collision.gameObject.CompareTag("paddle"))
        {
            ApplyEffect();
            Debug.Log("Apply Effect1");
            DestroyItem();
            
        }

        else if (collision.gameObject.CompareTag("levelmanager"))
            DestroyItem();
        
    }
}

public abstract class TimedItem : Item
{
    PowerUpManager pum;

   protected virtual void Start()
   {
       
        Debug.Log("timeditemstart");
        pum = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<PowerUpManager>();
        if (pum == null)
            Debug.Log("pum = null!!");
    }

    protected abstract TimedEffectType ItemName { get; }
    protected abstract float ItemTime { get; }

    protected override void ApplyEffect()
    {
        Debug.Log("Apply Effect2.1");
        ApplyTimedEffect();
        Debug.Log("Apply Effect2.2 ");
        
        pum.pumTimer(ItemName, ItemTime);
    }

    protected abstract void ApplyTimedEffect();
    
}

public enum TimedEffectType
{
    speedup,
    paddlesize
}
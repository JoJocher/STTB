using UnityEngine;

public class SpeedUpItem : TimedItem
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        Debug.Log("1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
       protected override TimedEffectType ItemName
       {
           get
           {
               return TimedEffectType.speedup;
           }
       }


       protected override float ItemTime
       {
           get
           {
               return 3f;
           }
       }
    
    protected override void ApplyTimedEffect()
       {
           SpeedUp();
        Debug.Log("speedup applytimedeffect gecalled");
    }

       void SpeedUp()
       {
        Debug.Log("Speedup aufgerufen");
        for (int i = 0; i < Ball.balls.Count; i++)
        {
            Ball.balls[i].SetMultiplier(5);
            Debug.Log("for schleife Speedup aufgerufen");
        }

       }
    

   
}

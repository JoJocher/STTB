using UnityEngine;

public class PaddleSizeItem : TimedItem

{

    /* PaddleSizeItem(Vector2 pos) : base(pos)
     {

     }
    */

    GameObject goPaddle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   override protected void Start()
    {
       goPaddle = GameObject.FindGameObjectWithTag("paddle");
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
      protected override TimedEffectType ItemName
    {
        get
        {
            return TimedEffectType.paddlesize;
        }
    }

    protected override float ItemTime
    {
        get
        {
            return 5f;
        }
    }

  protected override void ApplyTimedEffect()
    {
        PaddleSizeUp();
        Debug.Log("Apply Effect3");
    }
   
    void PaddleSizeUp()
    {
        goPaddle.GetComponent<Paddle>().PaddleSize(1.25f);
        Debug.Log("Apply Effect4");
    }


  
}

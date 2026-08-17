using UnityEngine;

public class DoubleBallItem : Item
{
    [SerializeField] GameObject ballPrefab;
    GameObject newBall;

    // Update is called once per frame
    protected override void Awake()
    {
        base.Awake();
       // ballPrefab = GameObject.FindGameObjectWithTag("ball");
    }



    protected override void ApplyEffect()
    {
        int ballCount = Ball.balls.Count;

        for (int i = 0; i < ballCount; i++)
        {
            
                //ball kriegt ne neue farbe
            newBall = Instantiate(ballPrefab, Ball.balls[i].transform.position, Quaternion.identity);
            newBall.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f /*Farbton*/, 0.7f, 1f /*Sättigung*/, 0.7f, 1f /*Helligkeit*/);

        }
    }
}

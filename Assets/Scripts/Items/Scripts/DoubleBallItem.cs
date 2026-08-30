using UnityEngine;

public class DoubleBallItem : Item
{
    [SerializeField] GameObject m_goBallPrefab;

    protected override void ApplyEffect()
    {
        //Prevent the newly spawned balls from adding additional ones during the same loop.
        int iBallCount = Ball.s_Balls.Count;
        if (iBallCount <= 10)
            for (int i = 0; i < iBallCount; i++)
            {
                GameObject goNewBall = Instantiate(m_goBallPrefab, Ball.s_Balls[i].transform.position, Quaternion.identity);
                goNewBall.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f /*Hue*/, 0.7f, 1f /*Saturation*/, 0.7f, 1f /*Brightness*/);
            }
    }
}

public class SpeedUpItem : TimedItem
{
    readonly float m_fNewSpeed = 5f;


    protected override TimedEffectType EffectType => TimedEffectType.SpeedUp;

    protected override float EffectDuration => 6f;

    protected override void ApplyTimedEffect() => SpeedUp();
   

    void SpeedUp()
    {
        for (int i = 0; i < Ball.s_Balls.Count; i++)
            Ball.s_Balls[i].SetSpeed(m_fNewSpeed);
    }
}

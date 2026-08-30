using UnityEngine;

public class PaddleSizeItem : TimedItem
{
    GameObject m_goPaddle;
    float m_fMaxPaddleSize;

    protected override void Start()
    {
        m_goPaddle = GameObject.FindGameObjectWithTag(ConstantValues.PaddleTag);
        m_fMaxPaddleSize = m_goPaddle.GetComponent<Paddle>().BasePaddleScaleX * Mathf.Pow(ConstantValues.PaddleSizeFactor, ConstantValues.MaxPaddleScaleIncreases); 
        base.Start();
    }

    protected override TimedEffectType EffectType => TimedEffectType.PaddleSize;

    protected override float EffectDuration => 8f;

    protected override void ApplyTimedEffect() => PaddleSizeUp();


    void PaddleSizeUp()
    {
        if (m_goPaddle.GetComponent<Transform>().localScale.x < m_fMaxPaddleSize)
            m_goPaddle.GetComponent<Paddle>().ScalePaddleWidth(ConstantValues.PaddleSizeFactor);
    }
}

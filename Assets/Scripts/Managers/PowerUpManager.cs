using UnityEngine;
using System.Collections.Generic;

public class PowerUpManager : MonoBehaviour
{
    static List<TimerData> s_timerList;

    void Awake()
    {
        s_timerList = new List<TimerData>();
    }

    void FixedUpdate()
    {
        for (int i = 0; i < s_timerList.Count; i++)
            if (s_timerList[i].m_bIsActive)
            {
                TimerData timer = s_timerList[i];

                if (timer.m_fTimerTime >= Time.fixedDeltaTime)
                    timer.m_fTimerTime -= Time.fixedDeltaTime;
                else
                {
                    timer.m_bIsActive = false;
                    BackToNormal(timer.m_effectType, timer.m_iCallAmount);
                    timer.m_iCallAmount = 0;
                }
                //TimerData is a struct. Changes have to be written back.
                s_timerList[i] = timer;
            }
    }

    void BackToNormal(TimedEffectType _timedEffectType, int _callAmount)
    {
        switch (_timedEffectType)
        {
            case TimedEffectType.PaddleSize:
                GameObject goPaddle = GameObject.FindGameObjectWithTag(ConstantValues.PaddleTag);

                if (goPaddle != null)
                {
                    Paddle paddle = goPaddle.GetComponent<Paddle>();
                    
                    for (; _callAmount > 0; _callAmount--)
                        paddle.ScalePaddleWidth(1f/ ConstantValues.PaddleSizeFactor);
                }
                break;

            case TimedEffectType.SpeedUp:
                for (int i = 0; i < Ball.s_Balls.Count; i++)
                    Ball.s_Balls[i].SetSpeed(Ball.s_Balls[i].BaseSpeed);

                break;
        }
    }

    public void ActivateTimer(TimedEffectType _timedEffectType, float _effectDuration)
    {
        bool bIsMissing = true;

        for (int i = 0; i < s_timerList.Count; i++)
        {
            TimerData timer = s_timerList[i];
            if (timer.m_effectType == _timedEffectType)
            {
                bIsMissing = false;

                timer.m_bIsActive = true;
                timer.m_fTimerTime = _effectDuration;

                if (_timedEffectType == TimedEffectType.PaddleSize && timer.m_iCallAmount < ConstantValues.MaxPaddleScaleIncreases)
                    timer.m_iCallAmount++;

                s_timerList[i] = timer;
                break;
            }
        }

        if (bIsMissing)
            s_timerList.Add(new TimerData(_effectDuration, _timedEffectType, true, 1));
    }
}

struct TimerData
{
    public TimerData(float _timerTime, TimedEffectType _timedEffectType, bool _isActive, int _callAmount)
    {
        m_fTimerTime = _timerTime;
        m_effectType = _timedEffectType;
        m_bIsActive = _isActive;
        m_iCallAmount = _callAmount;
    }

    public float m_fTimerTime;
    public TimedEffectType m_effectType;
    public bool m_bIsActive;
    public int m_iCallAmount;
}
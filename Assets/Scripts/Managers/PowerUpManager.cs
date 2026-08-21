using UnityEngine;
using System.Collections.Generic;

public class PowerUpManager : MonoBehaviour
{
    static List<TimerType> TimerList;
    //bool b;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        TimerList = new List<TimerType>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log("ES GIBT " + TimerList.Count + " TIMER!!");
        for (int i = 0; i < TimerList.Count; i++)// (TimerType t in TimerList)
        {

            //hier timer ablaufen lassen, prüfen ob er noch laufen darf
            //hier zudem effect abschalten wenn abgelaufen ist und bool isactive deaktivieren
            if (TimerList[i].isActive)
            {
              
               TimerType t = TimerList[i];
                Debug.Log("timer ist active! " + i);


                if (t.timerTime >= Time.fixedDeltaTime)
                {
                    t.timerTime -= Time.fixedDeltaTime;

                    TimerList[i] = t;

                    

                }
                else
                {
                    t.isActive = false;
                    TimerList[i] = t;

                    BackToNormal(TimerList[i].tet, t.callAmount);
                    t.callAmount = 0;
                    TimerList[i] = t;
                }
               }

            
        }


    }

    void BackToNormal(TimedEffectType et, int callAmount)
    {

        switch (et)
        {
            case TimedEffectType.paddlesize:
                for (; callAmount > 0; callAmount--)
                {
                    GameObject.FindGameObjectWithTag("paddle").GetComponent<Paddle>().PaddleSize(0.8f);
                    Debug.Log("call Amount ist " + callAmount);
                }
                
                //paddleSize Aufrufen;
                break;

            case TimedEffectType.speedup:
                 for( int i = 0; i < Ball.balls.Count; i++)
                {
                    Ball.balls[i].SetMultiplier(2);
                    Debug.Log("speedup Timer ende!");
                }
                break;
            
        }

     }

  public void pumTimer(TimedEffectType effecttype, float effectduration)
    {
       
        /*  bool isMissing = false;

          //hier timer aktivieren und prüfen, ob bereits läuft
          if (TimerList.Count > 0)
          {

              foreach (TimerType t in TimerList)
              {
                  if (t.tet != effecttype)
                      isMissing = true;
                  else
                  {
                      //bereits existenter Timer gefunden!
                      isMissing = false;
                      break;
                  }
              }



          }

          else
              isMissing = true;

         */
        bool isMissing = true;
/*
        foreach (TimerType t in TimerList)
        {

            if (t.tet == effecttype)
            {
                isMissing = false;
                t.isActive = true;
                break;
            }
        }*/

        for(int i = 0; i <TimerList.Count; i++)
        {
            TimerType t = TimerList[i];
            if (t.tet == effecttype)
            {
                isMissing = false;

                t.isActive = true;
                t.timerTime = effectduration;
                

                if (effecttype == TimedEffectType.paddlesize)
                    t.callAmount++;

                TimerList[i] = t;

                break;
            }
        }




        if (isMissing)
            TimerList.Add(new TimerType(effectduration, effecttype, true, 1));

        

      /*
        switch (effecttype)
        {
            case TimedEffectType.speedup: b = true; break;
        } */
    }
}

struct TimerType
{
    public TimerType(float tT, TimedEffectType _tet, bool b, int cA)
    {
        timerTime = tT;
        tet = _tet;

        isActive = b;
       callAmount = cA;
    }

    public float timerTime;
   public TimedEffectType tet;
    public bool isActive;
    public int callAmount;
}
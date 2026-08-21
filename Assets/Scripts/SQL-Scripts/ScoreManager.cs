using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int m_iScore; //{ get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
       // m_iScore = 50;
    }

    void Start()
    {
        StartCoroutine(PointTimer());
    }



    IEnumerator PointTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (m_iScore >= 1)
                m_iScore -= 1;
        }
    }

  public void AddPoint(PointType p_pointType)
    {
        switch (p_pointType)
        {
            case PointType.brick:
                m_iScore += 20;
                break;

            case PointType.item:
                m_iScore += 30;
                break;
        }
    }
}

public enum PointType
{
    brick,
    item
}

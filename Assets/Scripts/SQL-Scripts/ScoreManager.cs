using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField] public  int m_iScore; // { get; set; }
    public bool m_bTimerActive;
    string m_sName;

    HighscoreDatabase database;
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
        database = new HighscoreDatabase();
        database.CreateDatabase();
        database.CleanHighscores();


        StartCoroutine(PointTimer());
        //m_bTimerActive = true;
    }



    IEnumerator PointTimer()
    {
        while (m_bTimerActive)
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

    public void PointToList(string _name)
    {
        
        database.SaveHighscore(_name, m_iScore);
        m_sName = _name;
    }

   public List<string> PointsFromList()
    {
        
        List<HighscoreEntry> _hs = database.LoadHighscores();
        List<string> list = new List<string>();

        for (int i = 0; i < _hs.Count; i++)
        {
            list.Add((i+1) + "     " + _hs[i].playerName + "     " + _hs[i].Score);
            Debug.Log(list[i]);
        }


        return list;
    }

    public int LastEntryInRanking()
    {

        int rank = 1;
        List<HighscoreEntry> _hs = database.LoadHighscores();
        HighscoreEntry hse = _hs.First();
    
        
        for (int i = 1; i < _hs.Count; i++)
        {
            if (hse.Id < _hs[i].Id)
            {
                rank = i + 1;
                hse = _hs[i];
            }
            
        }
       
        return rank;

    }
    
}

public enum PointType
{
    brick,
    item
}


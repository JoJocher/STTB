using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }
    public bool IsTimerActive { get; private set; }
    public string PlayerName { get; private set; }

    HighscoreDatabase m_database;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        IsTimerActive = false;
    }

    void Start()
    {
        m_database = new HighscoreDatabase();
        m_database.CreateDatabase();
        m_database.CleanHighscores();
    }


    IEnumerator RunPointTimer()
    {
        while (IsTimerActive)
        {
            yield return new WaitForSeconds(1f);

            if (!IsTimerActive)
                break;

            if (Score >= 1)
                Score -= 1;
        }
    }

    public void StartPointTimer()
    {
        IsTimerActive = true;
        StartCoroutine(RunPointTimer());
    }

    public void StopPointTimer()
    {
        IsTimerActive = false;
    }

    public void AddPoints(PointType _pointType)
    {
        switch (_pointType)
        {
            case PointType.Brick:
                Score += 20;
                break;

            case PointType.Item:
                Score += 30;
                break;
        }
    }

    public void SaveResult(string _name)
    {
        m_database.SaveHighscore(_name, Score);
        PlayerName = _name;
    }

    public List<string> GetHighscoreList()
    {
        List<HighscoreEntry> highscoreEntries = m_database.LoadHighscores();
        List<string> highscoreList = new List<string>();

        for (int i = 0; i < highscoreEntries.Count; i++)
            highscoreList.Add((i + 1) + "     " + highscoreEntries[i].PlayerName + "     " + highscoreEntries[i].Score);
        return highscoreList;
    }

    public int GetRankOfLastEntry()
    {
        int iRank = 1;
        List<HighscoreEntry> highscoreEntries = m_database.LoadHighscores();
        HighscoreEntry latestHighscoreEntry = highscoreEntries.First();

        //The most recently saved entry is retrieved based on the highest Id
        for (int i = 1; i < highscoreEntries.Count; i++)
            if (latestHighscoreEntry.Id < highscoreEntries[i].Id)
            {
                iRank = i + 1;
                latestHighscoreEntry = highscoreEntries[i];
            }

        return iRank;
    }
}

public enum PointType
{
    Brick,
    Item
}
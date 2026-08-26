using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class LevelManager : MonoBehaviour
{
   [SerializeField] TMP_Text BrickCounter;
   [SerializeField] TMP_Text BallCounter;

   [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject GameWonUI;
    [SerializeField] GameObject HighscoreScreenUI;
    [SerializeField] GameObject MenuScreenUI;
    [SerializeField] GameObject PlayUI;

    [SerializeField] TMP_Text SubmittedText;
    [SerializeField] TMP_Text SubmittedTextFailed;

   // ScoreManager scoreManager;
    [SerializeField] TMP_Text scoreNumberText;

    int m_iBrickCountOld;
    int m_iBallCountOld;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
     //   scoreManager = this.gameObject.GetComponent<ScoreManager>().Instance;
    }
    void Start()
    {
        BrickCounterText();
        BallCounterText();
        ScoreCounterText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Brick.bricks.Count != m_iBrickCountOld)
            BrickCounterText();
        
        
        if (Ball.balls.Count != m_iBallCountOld)
            BallCounterText();
    

        if(Brick.bricks.Count <= 0)
        {
            //gewonnen
            //
           // gameObject.GetComponent<ScoreManager>().m_bTimerActive = false;
           // gameObject.GetComponent<ScoreManager>().m_iScore;

        }
    }


    void BrickCounterText()
    {
        m_iBrickCountOld = Brick.bricks.Count;
        BrickCounter.text = " " + Brick.bricks.Count;
    }

    void BallCounterText()
    {
        m_iBallCountOld = Ball.balls.Count;
        BallCounter.text = " " + Ball.balls.Count;
    }

    void ScoreCounterText()
    {
        scoreNumberText.text = " " + ScoreManager.Instance.m_iScore;
        
        
    }

    public void GameWonSubmit()
    {

        if (SubmittedText.text.Trim().Length >= 2)
        {
            ScoreManager.Instance.PointToList(SubmittedText.text);


            HighscoreScreen(true, false);
            Debug.Log("submittet text: " + SubmittedText.text);

            
        }
        else
            SubmittedTextFailed.gameObject.SetActive(true);
    }
    
    public void PlayScreen(bool _is)
    {
        PlayUI.SetActive(_is);
    }

    public void GameOver(bool _is)
    {
        GameOverUI.SetActive(_is);

    }

    public void GameWon(bool _is)
    {
        GameWonUI.SetActive(_is);
    }

    public void MenuScreen(bool _is)
    {
        MenuScreenUI.SetActive(_is);
    }

    public void HighscoreScreen(bool _isA, bool _isM)
    {
        HighscoreScreenUI.SetActive(_isA);
        if (_isA)
        {

            List<string> _hs = ScoreManager.Instance.PointsFromList();

            GameObject[] goListe = HighscoreScreenUI.GetComponent<HighscoreUI>().liste;

            for(int i = 0; i < _hs.Count; i++)
            {
                goListe[i].GetComponent<TMP_Text>().text = _hs[i];
            }

            if (_isM == false)
            {
                int iRank = ScoreManager.Instance.LastEntryInRanking();
                int iSCore = ScoreManager.Instance.m_iScore;

                goListe[10].gameObject.SetActive(true);
                goListe[10].GetComponent<TMP_Text>().text = "Your Rank: " + iRank + " Your Score: " + iSCore;
            }
            else
            {
               // goListe[10].GetComponent<TMP_Text>().text = " ";
                goListe[10].gameObject.SetActive(false);
            }
        }

    }

    //public void HighscoreScreen(bool _isA)
    //{
    //    HighscoreScreenUIl.SetActive(_isA);
    //}

}
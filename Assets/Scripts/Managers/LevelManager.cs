using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] TMP_Text m_brickCounterText;
    [SerializeField] TMP_Text m_ballCounterText;

    [SerializeField] GameObject m_gameOverScreenUI;
    [SerializeField] GameObject m_gameWonScreenUI;
    [SerializeField] GameObject m_highscoreScreenUI;
    [SerializeField] GameObject m_menuScreenUI;
    [SerializeField] GameObject m_playScreenUI;

    [SerializeField] TMP_InputField m_submittedNameInputField;
    [SerializeField] TMP_Text m_invalidSubmittedText;

    [SerializeField] TMP_Text m_scoreText;

    int m_iBrickCountOld;
    int m_iBallCountOld;
    int m_iScoreOld;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        UpdateBrickCounterText();
        UpdateBallCounterText();
        UpdateScoreCounterText();
    }

    void Update()
    {
        if (Brick.s_Bricks.Count != m_iBrickCountOld)
            UpdateBrickCounterText();
        if (Ball.s_Balls.Count != m_iBallCountOld)
            UpdateBallCounterText();
        if (ScoreManager.Instance.IsTimerActive && ScoreManager.Instance.Score != m_iScoreOld)
            UpdateScoreCounterText();
    }


    void UpdateBrickCounterText()
    {
        m_iBrickCountOld = Brick.s_Bricks.Count;
        m_brickCounterText.text = Brick.s_Bricks.Count.ToString();
    }

    void UpdateBallCounterText()
    {
        m_iBallCountOld = Ball.s_Balls.Count;
        m_ballCounterText.text = Ball.s_Balls.Count.ToString();
    }

    void UpdateScoreCounterText()
    {
        m_iScoreOld = ScoreManager.Instance.Score;
        m_scoreText.text = ScoreManager.Instance.Score.ToString();
    }

    public void GameWonSubmit()
    {

        if (m_submittedNameInputField.text.Length >= 2)
        {
            ScoreManager.Instance.SaveResult(m_submittedNameInputField.text);
            SetHighscoreScreen(true, false);
        }
        else
            m_invalidSubmittedText.gameObject.SetActive(true);
    }

    public void SetPlayScreenActive(bool _isActive)
    {
        m_playScreenUI.SetActive(_isActive);
    }

    public void SetGameOverScreenActive(bool _isActive)
    {
        m_gameOverScreenUI.SetActive(_isActive);
    }

    public void SetGameWonScreenActive(bool _isActive)
    {
        m_gameWonScreenUI.SetActive(_isActive);
    }

    public void SetMenuScreenActive(bool _isActive)
    {
        m_menuScreenUI.SetActive(_isActive);
    }

    public void SetHighscoreScreen(bool _isActive, bool _isFromMenu)
    {
        m_highscoreScreenUI.SetActive(_isActive);
        if (_isActive)
        {

            List<string> highscoreList = ScoreManager.Instance.GetHighscoreList();

            GameObject[] highscoreUIElements = m_highscoreScreenUI.GetComponent<HighscoreUI>().HighscoreUIElements;
            // The last UI element is reserved for displaying the final rank of the player
            int iLastUIElementIndex = highscoreUIElements.Length - 1;

            for (int i = 0; i < highscoreList.Count; i++)
                highscoreUIElements[i].GetComponent<TMP_Text>().text = highscoreList[i];

            if (!_isFromMenu)
            {
                int iRank = ScoreManager.Instance.GetRankOfLastEntry();
                int iScore = ScoreManager.Instance.Score;
                string strPlayerName = ScoreManager.Instance.PlayerName;

                highscoreUIElements[iLastUIElementIndex].SetActive(true);
                highscoreUIElements[iLastUIElementIndex].GetComponent<TMP_Text>().text = strPlayerName + "! Your Rank: " + iRank + " Your Score: " + iScore;
            }
            else
            {
                highscoreUIElements[iLastUIElementIndex].SetActive(false);
            }
        }

    }
}

public static class ConstantValues
{
    public const string ItemTag = "item";
    public const string PaddleTag = "paddle";
    public const string GameScene = "GameScene";
    public const string BallTag = "ball";
    public const string LevelmanagerTag = "levelmanager";

    public const int MaxPaddleScaleIncreases = 3;
    public const float PaddleSizeFactor = 1.25f;

}
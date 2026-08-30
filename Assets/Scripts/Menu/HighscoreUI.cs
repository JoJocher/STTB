using UnityEngine;


public class HighscoreUI : MonoBehaviour
{
  [SerializeField] GameObject[] m_highscoreUIElements = new GameObject[11];
    public GameObject[] HighscoreUIElements => m_highscoreUIElements;
}

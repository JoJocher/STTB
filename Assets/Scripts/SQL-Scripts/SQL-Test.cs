using System.Collections.Generic;
using UnityEngine;

//Test class for testing Database actions
public class SQLTest : MonoBehaviour
{
 void Start()
 {
      HighscoreDatabase database = new HighscoreDatabase();
      database.CreateDatabase();
      database.SaveHighscore("TestPlayer4", 430);
      database.SaveHighscore("TestPlayer5", 17);
      database.SaveHighscore("TestPlayer6", 23);
      database.SaveHighscore("TestPlayer7", 7650);
      database.SaveHighscore("TestPlayer8", 210);
      database.SaveHighscore("TestPlayer9", 54);
      database.SaveHighscore("TestPlayer10", 460);
      database.SaveHighscore("TestPlayer11", 90);

    List<HighscoreEntry> highscoreEntries = database.LoadHighscores();

    foreach (HighscoreEntry entry in highscoreEntries)
        Debug.Log(entry.PlayerName + " : " + entry.Score);

    database.CleanHighscores();

    highscoreEntries = database.LoadHighscores();

    foreach (HighscoreEntry entry in highscoreEntries)
        Debug.Log("Cleared List: " + entry.PlayerName + " : " + entry.Score);
  }
}

using SQLite;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreDatabase
{

    readonly string m_strPath = Path.Combine(Application.persistentDataPath, "highscores.db");
    public void CreateDatabase()
    {
        using (SQLiteConnection connection = new SQLiteConnection(m_strPath))
        {
            connection.Execute(
               @"CREATE TABLE IF NOT EXISTS Highscores ( Id INTEGER PRIMARY KEY AUTOINCREMENT, PlayerName TEXT NOT NULL, Score INTEGER NOT NULL );");

        }
    }

    public void SaveHighscore(string _playerName, int _score)
    {
        using (SQLiteConnection connection = new SQLiteConnection(m_strPath))
        {
            connection.Execute("INSERT INTO Highscores (PlayerName, Score) VALUES (?, ?);", _playerName, _score);
        }
    }

    public List<HighscoreEntry> LoadHighscores()
    {
        using (SQLiteConnection connection = new SQLiteConnection(m_strPath))
        {
            List<HighscoreEntry> highscoreEntries = connection.Query<HighscoreEntry>("SELECT Id, PlayerName, Score FROM Highscores ORDER BY Score DESC, Id Asc;");

            return highscoreEntries;
        }
    }

    public void CleanHighscores()
    {
        using (SQLiteConnection connection = new SQLiteConnection(m_strPath))
        {
            connection.Execute(@"DELETE FROM Highscores WHERE Id NOT IN ( SELECT Id FROM Highscores ORDER BY Score DESC, Id ASC LIMIT 10);");

        }
    }
}

public class HighscoreEntry
{
    public int Id { get; set; }
    public int Score { get; set; }
    public string PlayerName { get; set; }
}

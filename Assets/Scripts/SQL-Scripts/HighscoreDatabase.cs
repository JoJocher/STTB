using UnityEngine;
using SQLite;
using System.IO;
using System.Collections.Generic;

public class HighscoreDatabase
{
    public void CreateDatabase()
    {
        string path = Path.Combine(Application.persistentDataPath, "highscores.db");

        SQLiteConnection connection = new SQLiteConnection(path);

        Debug.Log(path);

       

        connection.Execute(
           @"CREATE TABLE IF NOT EXISTS Highscores ( Id INTEGER PRIMARY KEY AUTOINCREMENT, playerName TEXT NOT NULL, Score INTEGER NOT NULL );");

        connection.Close();
       
    }

    public void SaveHighscore(string pName, int score)
    {
        string path = Path.Combine(Application.persistentDataPath, "highscores.db");
        SQLiteConnection connection = new SQLiteConnection(path);
        connection.Execute("INSERT INTO Highscores (playerName, Score) VALUES (?, ?);", pName, score);
    
        connection.Close();
    }

    public List<HighscoreEntry> LoadHighscores()
    {
        string path = Path.Combine(Application.persistentDataPath, "highscores.db");

        SQLiteConnection connection = new SQLiteConnection(path);
        List<HighscoreEntry> highscores = connection.Query<HighscoreEntry>("SELECT Id, playerName, Score FROM Highscores ORDER BY Score DESC;");
        connection.Close();
        return highscores;

    }

    public void CleanHighscores()
    {
        string path = Path.Combine(Application.persistentDataPath, "highscores.db");
        SQLiteConnection connection = new SQLiteConnection(path);
        connection.Execute(@"DELETE FROM Highscores WHERE Id NOT IN ( SELECT Id FROM Highscores ORDER BY Score DESC, Id ASC LIMIT 10);");
        connection.Close();
    }
}

public class HighscoreEntry
{
    public int Id { get; set; }
    public int Score { get; set; }
    public string playerName { get; set; }
}

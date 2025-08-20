using UnityEngine;
using System.IO;
public class GameData
{
    public int CoinCount;
    public int ScoreCount;
    public int MaxScoreCount;
    public string Save(string ScoreFile)
    {
        string json;
        if (ScoreCount > MaxScoreCount)
        {
            MaxScoreCount = ScoreCount;
        }
        if (File.Exists(ScoreFile))
        {
            json = File.ReadAllText(ScoreFile);
            GameData data = JsonUtility.FromJson<GameData>(json);
            if (MaxScoreCount < data.MaxScoreCount)
            {
                data.MaxScoreCount = MaxScoreCount;
                json = JsonUtility.ToJson(data);
                return json;
            }

        }
        
        json = JsonUtility.ToJson(this);
        return json;

    }
    public void Load(string ScoreFile)
    {
        string json;
        if (File.Exists(ScoreFile))
        {
            json = File.ReadAllText(ScoreFile);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        ScoreCount = 0;
    }
    
}

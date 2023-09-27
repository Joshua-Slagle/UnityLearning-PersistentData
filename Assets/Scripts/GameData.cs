using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Instrumentation;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public string currentPlayerName;
    public string highScorePlayerName = "";
    public int highScore = 0;

    public static GameData Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null) {
            Destroy(this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.LoadPlayerData();
    }

    public void SavePlayerData()
    {
        SaveData saveData = new SaveData();
        saveData.highScore = this.highScore;
        saveData.highScorePlayerName = this.currentPlayerName;

        string json_data = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json_data);
    }

    public void LoadPlayerData()
    {
        string data_path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(data_path)) {
            string json_data = File.ReadAllText(data_path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json_data);

            this.highScorePlayerName = saveData.highScorePlayerName;
            this.highScore = saveData.highScore;
        }
    }

    public string PrintHighScoreText() 
    {
        return "Best Score: " + GameData.Instance.highScorePlayerName + ": " + GameData.Instance.highScore.ToString();
    }
}

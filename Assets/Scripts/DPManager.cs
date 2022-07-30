using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DPManager : MonoBehaviour
{
    public static DPManager Instance;

    public string playerName;
    public int highScore;
    public string highScorePlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDetails();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
        public string highScorePlayer;
    }

    public void SaveDetails()
    {
        SaveData data = new SaveData();

        data.playerName = playerName;
        data.highScore = highScore;
        data.highScorePlayer = highScorePlayer;

        if (data.playerName == "DELETE")
        {
            data.playerName = "";
            data.highScore = 0;
            data.highScorePlayer = "";
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadDetails()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
            highScorePlayer = data.highScorePlayer;
        }

    }
}

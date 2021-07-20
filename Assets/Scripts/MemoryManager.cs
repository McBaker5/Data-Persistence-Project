using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MemoryManager : MonoBehaviour
{
    public static MemoryManager Instance;

    public new string name;
    public string hiScoreName;
    public int hiScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHiScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int hiScore;
        public string hiScoreName;
    }

    public void SaveHiScore(int score)
    {
        hiScore = score;
        hiScoreName = name;
        SaveData data = new SaveData();
        data.hiScore = hiScore;
        data.hiScoreName = hiScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiScore = data.hiScore;
            hiScoreName = data.hiScoreName;
        }
    }
}

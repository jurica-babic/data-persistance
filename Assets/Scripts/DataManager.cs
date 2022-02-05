using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public int score;
    public string playerName;

    public static DataManager Instance {private set; get;}

    void Awake()
    {
        if(Instance != null){
            Destroy(gameObject);
            return;
        } 
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();

    }



    [System.Serializable]
    public class SaveData{
        public int score;
        public string playerName;
    }

    private const string PATH_ADD = "/save.json";

    public string GetSavePath(){
        return Application.persistentDataPath + PATH_ADD;
    }

    public void Load(){
        if(!File.Exists(GetSavePath())) return;

        string json = File.ReadAllText(GetSavePath());
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        score = data.score;
        playerName = data.playerName;
    }

    public void Save(){
        SaveData data = new SaveData();
        data.score = score;
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(GetSavePath(),json);
    }

}

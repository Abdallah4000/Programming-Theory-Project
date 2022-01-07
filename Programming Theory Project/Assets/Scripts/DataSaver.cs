using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataSaver : MonoBehaviour
{
    public static DataSaver instance;

    public int level;


    public int EasyScore;
    
    public int MediumScore;
    
    public int HardScore;

    
    public int TScore = 0;
    public int TScore2 = 0;


    


    private void Awake() {

        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this ;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int EasyScore;
        
        public int MediumScore;
        
        public int HardScore;
    }

    public void SaveScore()
    {
        SaveData DScore = new SaveData();

        DScore.EasyScore = EasyScore;
        DScore.MediumScore = MediumScore;
        DScore.HardScore = HardScore;

        string json = JsonUtility.ToJson(DScore);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json",json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/SaveFile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData DScore = JsonUtility.FromJson<SaveData>(json);
            EasyScore = DScore.EasyScore;
            MediumScore = DScore.MediumScore;
            HardScore = DScore.HardScore;
        }
    }
 
}

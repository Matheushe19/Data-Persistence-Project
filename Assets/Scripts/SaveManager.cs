using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Microsoft.SqlServer.Server;
using UnityEditor.Experimental.RestService;

namespace GameSystem
{
    public class SaveManager : MonoBehaviour
    {
        public string PlayerName;
        public int PlayerHighScore;

        public static SaveManager instance;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            LoadHighScore();
            DontDestroyOnLoad(gameObject);
       
        }

        public void ReceivePlayerName(string Name)
        { 
            PlayerName = Name;
            
        }

        //save player infos
        public void SaveScore(int score)
        {
            SaveData Playerdata = new SaveData();

            if (score > Playerdata.HighScore)
            {
                Playerdata.HighScoreName = PlayerName;
                Playerdata.HighScore = score;
            }
            string json = JsonUtility.ToJson(Playerdata);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        //load player highscore
        public void LoadHighScore()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData Playerdata = JsonUtility.FromJson<SaveData>(json);

                PlayerName = Playerdata.HighScoreName;
                PlayerHighScore = Playerdata.HighScore;

            }
        }
    }

    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
        
    }

}
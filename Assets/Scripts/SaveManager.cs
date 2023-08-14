using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Microsoft.SqlServer.Server;
using UnityEditor.Experimental.RestService;
using UnityEngine.UI;

namespace GameSystem
{
    public class SaveManager : MonoBehaviour
    {
        public string playerName;//current player name
        public string playerHighScoreName; //name of the player with the highest score
        public int playerHighScore; //highest recorded score

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

        public void NameChange(string playerNameInputField)
        { 
         playerName = playerNameInputField;
        }

        //save player infos
        public void SaveScore(int score)
        {
            SaveData Playerdata = new SaveData();

            //saves the player's name if the score is higher than previously registered
            if (score > playerHighScore)
            {
                Playerdata.HighScoreName = playerName;
                Playerdata.HighScore = score;
            }
            //if not, it continues with the highest recorded score
            else
            { 
                Playerdata.HighScoreName = playerHighScoreName;
                Playerdata.HighScore = playerHighScore;
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

                playerHighScoreName = Playerdata.HighScoreName;
                playerHighScore = Playerdata.HighScore;

            }
        }
    }

    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
        
    }

}
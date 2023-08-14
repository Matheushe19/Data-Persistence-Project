using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class LoadSystem : MonoBehaviour
    {

        public void OnStart()
        {
            //Load the game Scene
            SceneManager.LoadScene(1);
        }

        public void OnReturn()
        {

            //Load Menu Scene
            SceneManager.LoadScene(0);
            SaveManager.instance.LoadHighScore();
        }

        public void OnAppExit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif
        }
    }

}

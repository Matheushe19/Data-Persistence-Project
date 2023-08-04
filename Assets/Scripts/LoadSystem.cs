using System.Collections;
using System.Collections.Generic;
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
    }

}

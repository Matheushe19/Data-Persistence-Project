using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager instance;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
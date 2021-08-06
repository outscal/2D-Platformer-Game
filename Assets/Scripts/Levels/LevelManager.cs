using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        public static LevelManager Instance { get { return instance;  } }


        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus =  (LevelStatus)PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }

        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
        }
    }
}
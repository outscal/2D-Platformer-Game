using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;

        public string[] Levels;

        public static LevelManager Instance { get { return instance; } }

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

        private void Start()
        {
            if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
            {
                SetLevelStatus(Levels[0], LevelStatus.Unlocked);
            }
        }

        public void MarkLevelComplete()
        {
            int CurrentIndex = Array.FindIndex(Levels, level => level == SceneManager.GetActiveScene().name);

            SetLevelStatus(Levels[CurrentIndex], LevelStatus.Completed);

            if(CurrentIndex + 1 < Levels.Length)
            {
                SetLevelStatus(Levels[CurrentIndex + 1], LevelStatus.Unlocked);
            }
        }

        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }

        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
        }
    }
}
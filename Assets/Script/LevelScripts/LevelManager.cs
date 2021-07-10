using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

namespace Elle2D
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;

        [SerializeField]
        private string[] Levels;
        public static LevelManager Instance { get { return instance; } }
        private void Awake()
        {
            if (instance == null)
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
            if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
            {
                SetLevelStatus(Levels[0], LevelStatus.Unlocked);
            }
        }

        public LevelStatus GetLevelStatus(string level)
        {
            LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
            return levelStatus;
        }

        public void MarkCurrentLevelComplete()
        {
            Scene currentscene = SceneManager.GetActiveScene();
            LevelManager.Instance.SetLevelStatus(currentscene.name, LevelStatus.Completed);
            int currentSceneIndex = Array.FindIndex(Levels, level => level == currentscene.name);
            int nextSceneINdex = currentSceneIndex + 1;
            if (nextSceneINdex < Levels.Length)
            {
                SetLevelStatus(Levels[nextSceneINdex], LevelStatus.Unlocked);
            }
        }


        public void SetLevelStatus(string level, LevelStatus levelStatus)
        {
            PlayerPrefs.SetInt(level, (int)levelStatus);
        }
    }
}
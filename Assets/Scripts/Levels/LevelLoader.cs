using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        private Button button;
        public string LevelName;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(onClick);
        }

        private void onClick()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
            switch(levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("can't Play this level, till you unlock it");
                    break;

                case LevelStatus.Unlocked:
                    Debug.Log(LevelName);
                    SceneManager.LoadScene(LevelName);
                    break;

                case LevelStatus.Completed:
                    SceneManager.LoadScene(LevelName);
                    break;
            }
            SceneManager.LoadScene(LevelName);
            //throw new NotImplementedException();
        }
    }
}
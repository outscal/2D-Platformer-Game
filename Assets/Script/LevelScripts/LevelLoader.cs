using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Elle2D
{
    [RequireComponent(typeof(Button))]
    public class LevelLoader : MonoBehaviour
    {
        private Button button;
        public string LevelName;
        private void Awake()
        {
            // PlayerPrefs.DeleteAll();
            button = GetComponent<Button>();
            button.onClick.AddListener(onClick);
        }
 
        private void onClick()
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Can't play this level till you unlock it");
                    break;

                case LevelStatus.Unlocked:
                    Debug.Log("Unlocked");
                    SceneManager.LoadScene(LevelName);
                    break;

                case LevelStatus.Completed:
                    Debug.Log("Completed");
                    SceneManager.LoadScene(LevelName);
                    break;
            }

        }
    }
}
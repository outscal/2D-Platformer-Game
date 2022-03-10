using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Levels
{
    [RequireComponent(typeof(Button))]

    public class LevelLoader : MonoBehaviour
    {
        private Button button;
        [SerializeField] private string levelName;
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(LevelSelect);
        }

        private void LevelSelect()
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
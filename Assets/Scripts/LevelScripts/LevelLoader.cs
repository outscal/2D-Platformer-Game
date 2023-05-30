using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    [SerializeField] private string levelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (SceneManager.GetActiveScene().name == "LevelComplete")
        {
            button.onClick.AddListener(LoadNextLevel);
        }
        else
        {
            button.onClick.AddListener(onClick);
        } 
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = LevelManager.Instance.nextSceneIndex;
        // nextSceneIndex would be according to the Levels array not as per the Unity Build Index
        if (nextSceneIndex < LevelManager.Instance.Levels.Length)
        {
            levelName = LevelManager.Instance.Levels[LevelManager.Instance.nextSceneIndex];
            SceneManager.LoadScene(levelName);
        }
    }

    private void onClick()
    {
        LevelStatus status = LevelManager.Instance.GetLevelStatus(levelName);
        switch (status)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Locked. Unlock it to play");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}

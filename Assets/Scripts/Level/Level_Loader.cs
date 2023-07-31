using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Level_Loader : MonoBehaviour
{
    private Button button;

    [SerializeField] string LevelName;


    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        string currentLevel = PlayerPrefs.GetString("CurrentLevel", LevelName);
        SceneManager.LoadScene(LevelName);
    }
}

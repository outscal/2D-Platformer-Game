using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelTextUpdate : MonoBehaviour
{
    private TextMeshProUGUI levelText_UI;

    private void Awake()
    {
        levelText_UI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        levelText_UI.text = "Level : " + (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        SceneController.instance.LoadScene(1);
    }
}

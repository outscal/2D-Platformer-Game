using UnityEngine;
using UnityEngine.UI;


public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject LevelSelection;

    private void Awake()
    {
        playButton.onClick.AddListener(Playgame);
    }

    private void Playgame()
    {
        LevelSelection.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public GameObject levelSelection;

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.Instance.Play(SoundType.ButtonClick);
    }

    public void OpenLevelSelection()
    {
        AudioManager.Instance.Play(SoundType.ButtonClick);
        levelSelection.SetActive(true);
    }

}

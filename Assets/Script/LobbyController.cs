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
    }

    public void OpenLevelSelection()
    {
        levelSelection.SetActive(true);
    }

}

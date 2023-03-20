using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button PlayGameButton;
    void Start()
    {
        PlayGameButton.onClick.AddListener(PlayeGame);
    }

    // Update is called once per frame
   


    private void PlayeGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


}

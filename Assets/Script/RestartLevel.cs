using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    // public Button button;
    public string restartGame;

    // public void Start()
    // {
    //     button.onClick.AddListener(onButtonClick);
    // }
    public void onButtonClick()
    {
        SceneManager.LoadScene(restartGame);

    }

}

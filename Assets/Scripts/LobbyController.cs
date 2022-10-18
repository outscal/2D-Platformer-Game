using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{

    public Button buttonStart;
    public Button buttonQuit;


    public void ButtonStart()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ButtonQuit()
    {
        SceneManager.LoadScene(0);
    }
}

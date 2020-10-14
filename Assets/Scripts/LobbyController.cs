using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;

    private void Start()
    {

        playButton.onClick.AddListener(LoadLevel1);

    }

    void LoadLevel1()
    {

        SceneManager.LoadScene(1); 


    }




}

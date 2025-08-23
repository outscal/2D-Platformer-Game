using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Controller : MonoBehaviour
{

    [SerializeField] private Relode_Level relodeLevel;
     

    public void OnRestartButtonClicked()
    {
        relodeLevel.ReloadScene();
    }
    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene(0); 
    }
}



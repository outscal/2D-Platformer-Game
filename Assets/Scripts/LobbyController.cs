using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;
    private void Awake(){
        buttonPlay.onClick.AddListener(playGame);
        
    }
    private void playGame(){
        
        LevelSelection.SetActive(true);
    }
    
}

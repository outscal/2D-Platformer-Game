using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public GameObject levelSelectionPopUp;
    private const string scene1 = "Level1";
    private void Awake() {
        playButton.onClick.AddListener(SelectLevel);
        quitButton.onClick.AddListener(QuitGame);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectLevel(){
        levelSelectionPopUp.SetActive(true);
    }
    
    private void QuitGame(){
        Application.Quit();
        Debug.Log("Quits the game!");
    }

    public void CloseButton(){
        levelSelectionPopUp.SetActive(false);
    }
}

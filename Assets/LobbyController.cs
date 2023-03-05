using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button ButtonPlay;
    public GameObject LevelSelection;
    // Start is called before the first frame update
    void Start()
    {
        ButtonPlay.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayGame()
    {
        LevelSelection.SetActive(true);
    }
}

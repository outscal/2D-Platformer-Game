using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button PlayGameButton;
    public GameObject levelSelectionPanel;
    private void Awake()
    {

        levelSelectionPanel.SetActive(false);
    }
    void Start()
    {
        PlayGameButton.onClick.AddListener(PlayeGame);
        
    }

    // Update is called once per frame
   


    private void PlayeGame()
    {
        SoundManager.Instance.PlaySounds(Sounds.ButtonClick);
        levelSelectionPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLevel : MonoBehaviour
{
   [SerializeField] private Button button;
    [SerializeField] GameObject LevelSlectionPanel;
    void Awake()
    {
        LevelSlectionPanel.SetActive(false);
        button.onClick.AddListener(OpenPanel);

    }

   
    private void OpenPanel()
    {
        LevelSlectionPanel.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Game is Exit");
        Application.Quit();

    }
}

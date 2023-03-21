using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLaoder : MonoBehaviour
{
    public Button levelButton;
    public string LevelName;
    private void Awake()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(OnClickLoad);
    }

    private void OnClickLoad()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
   
    private Button button;
    public string LevelName;

    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick()
    {
        SceneManager.LoadScene(LevelName);
    }
}

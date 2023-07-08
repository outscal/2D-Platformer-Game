using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
   
    private Button button;
    public string levelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        //throw new NotImplementedException();
        SceneManager.LoadScene(levelName);
    }
}

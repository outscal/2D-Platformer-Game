using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{   

    public string levelName;
    private Button button;
    

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        SceneManager.LoadScene(levelName);
    }
}

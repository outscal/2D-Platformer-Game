using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button button;
    private void Awake()
    {
        button.onClick.AddListener(play);
    }
    // Start is called before the first frame update
    private void play()
    {
        SceneManager.LoadSceneAsync(1);
    }
}

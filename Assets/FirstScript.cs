using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstScript : MonoBehaviour
{
    public Button button;
    public string newScene;
    // Start is called before the first frame update
    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene(newScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

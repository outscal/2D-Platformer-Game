using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(Button))]
public class GoNextLevel : MonoBehaviour
{ 
    private Button button;
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    private void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene(NextScene);
    }
}

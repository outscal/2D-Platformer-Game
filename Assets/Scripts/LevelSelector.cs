using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelSelector : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void onClick(){
        SceneManager.LoadScene(LevelName);
    }
}

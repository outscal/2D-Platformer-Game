using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    private Button buttons;
    void Start()
    {
        buttons = GetComponent<Button>();
        buttons.onClick.AddListener(Restartlevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Restartlevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(Button))]
public class GoNextLevel : MonoBehaviour
{ 
    private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        
    }

    // Update is called once per frame
    public void MainMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene("MainMenu");
       
    }
    public void RestartLevel()
    {
       SoundManager.Instance.Play(Sounds.ButtonClick);
       Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    public void NextLevel()
    {
         SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

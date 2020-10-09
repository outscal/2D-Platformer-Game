using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Button buttonRestart,buttonQuit;
    int currentSceneLoad;
    private void Awake(){
        currentSceneLoad=SceneManager.GetActiveScene().buildIndex;
        buttonRestart.onClick.AddListener(LoadScene);
        buttonQuit.onClick.AddListener(LoadMainMenu);
    }
    public void PlayerDied(){
        gameObject.SetActive(true);
    }
    public void LoadScene(){
         SceneManager.LoadScene(currentSceneLoad);
         
    }
    public void LoadMainMenu(){
        SceneManager.LoadScene(0);
    }
 
    
}

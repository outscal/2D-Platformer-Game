using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Button buttonRestart;
    int currentSceneLoad;
    private void Awake(){
        currentSceneLoad=SceneManager.GetActiveScene().buildIndex;
        buttonRestart.onClick.AddListener(LoadScene);
    }
    public void PlayerDied(){
        gameObject.SetActive(true);
    }
    public void LoadScene(){
         SceneManager.LoadScene(currentSceneLoad);
         
    }
 
    
}

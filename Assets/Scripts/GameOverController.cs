using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;


    private void Awake() {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
   public void PlayerDied(){
       gameObject.SetActive(true);
   }

    private void ReloadLevel()
    {
        // SceneManager.LoadScene(1);
        Debug.Log("Reloading Scene");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);

    }
}

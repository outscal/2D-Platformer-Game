using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public Button buttonRestart;

    private void Awake()
    {
        Debug.Log("Level Restart");
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
    
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    void ReloadLevel()
    {
        Debug.Log("Reloading Scene.....");
        //SceneManager.LoadScene(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

}

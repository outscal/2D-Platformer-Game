using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameOver_Controller : MonoBehaviour
{
    [SerializeField] Button restartButton;
    //[SerializeField] Button quitButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadScene);
        //quitButton.onClick.AddListener(QuitGame);
    }


    public void PlayerDied()
    {
        gameObject.SetActive(true);
 
    }

    //Reload Function
    void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    /*void QuitGame()
    {
        //Application.Quit();
        EditorApplication.isPlaying = false;
    }
*/
}

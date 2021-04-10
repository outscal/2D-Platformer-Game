using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public Button buttonRestart;

    private void Awake()
    {
        Debug.Log("not able to reload");
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
    
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    void ReloadLevel()
    {
        Debug.Log("Reloading Scene 0");
        SceneManager.LoadScene(1);
    }

}

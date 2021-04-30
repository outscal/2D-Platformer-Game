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
        //SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }

    void ReloadLevel()
    {
        Debug.Log("Reloading Scene.....");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

}


using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string level;
    public string lobby;
   public void Restart()
    {
        SceneManager.LoadScene(level);
    }
    public void Lobby()
    {
        SceneManager.LoadScene(lobby);
    }
}

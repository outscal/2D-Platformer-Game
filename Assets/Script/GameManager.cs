using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    internal void resetGame()
    {
        SceneManager.LoadScene(2);
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ForwardScript : MonoBehaviour
{
    public void nextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

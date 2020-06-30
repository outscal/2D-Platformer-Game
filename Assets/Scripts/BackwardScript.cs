using UnityEngine;
using UnityEngine.SceneManagement;

public class BackwardScript : MonoBehaviour
{
    public void previousScene()
    {
        SceneManager.LoadScene(0);
    }
}

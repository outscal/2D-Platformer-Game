using UnityEngine.SceneManagement;

public class SceneLoader 
{
    static int totalScenes = 2;
    public static void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int loadSceneIndex = nextSceneIndex < totalScenes ? nextSceneIndex : 0;
        SceneManager.LoadScene(loadSceneIndex);
    }

    public static void LoadAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

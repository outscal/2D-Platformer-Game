using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Level completed");
        sceneIndex++;
        if (sceneIndex == 3)
        {
            sceneIndex = 0;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
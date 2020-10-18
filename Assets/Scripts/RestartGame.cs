using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison) {
        if(collison.gameObject.GetComponents<PlayerController>() != null){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
            // SceneManager.LoadScene("Level1");
            Debug.Log("New Scene loaded");
        }
    }
}

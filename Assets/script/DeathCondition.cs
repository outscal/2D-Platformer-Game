using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathCondition : MonoBehaviour
{
    private int currentSceneLoad;
    private void Awake(){
        currentSceneLoad=SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D collider){
        SceneManager.LoadScene(currentSceneLoad);
    }
    void SceneLoader(int scene){
        SceneManager.LoadScene(scene);
    }
}

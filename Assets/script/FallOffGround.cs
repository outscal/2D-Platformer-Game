using UnityEngine.SceneManagement;
using UnityEngine;

public class FallOffGround : MonoBehaviour
{
    private int currentSceneLoad;
    private void Awake(){
        currentSceneLoad=SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D collider){
        SceneManager.LoadScene(currentSceneLoad);
    }
   
}

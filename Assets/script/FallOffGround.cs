using UnityEngine.SceneManagement;
using UnityEngine;

public class FallOffGround : MonoBehaviour
{
    private int currentSceneLoad;
    private void Awake(){
        currentSceneLoad=SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.GetComponent<PlayerControll>()!=null){
        SceneManager.LoadScene(currentSceneLoad);
    }
    }
   
}

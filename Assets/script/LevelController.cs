using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
 {
     private int nextSceneLoad;
     private void Start(){
         nextSceneLoad=SceneManager.GetActiveScene().buildIndex+1;
     }
private    void OnTriggerEnter2D(Collider2D collider){
            SceneManager.LoadScene(nextSceneLoad);
     }
    
    void MySceneLoader(int sceneLoader){
        SceneManager.LoadScene(sceneLoader);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LevelController : MonoBehaviour
 {
     //public GameOverController game;
     private int nextSceneLoad;
     public LevelOverController levelOver;
     private void Awake(){
         nextSceneLoad=SceneManager.GetActiveScene().buildIndex+1;
     }
     
private    void OnTriggerEnter2D(Collider2D collider){
            levelOver.Over();
           StartCoroutine(WaitSec());
            
     }
     IEnumerator WaitSec(){
         yield return new WaitForSeconds(1);
         SceneManager.LoadScene(nextSceneLoad);
     }
    
   }


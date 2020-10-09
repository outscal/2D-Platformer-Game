using UnityEngine.SceneManagement;
using UnityEngine;

public class FallOffGround : MonoBehaviour
{
    public Animator animator;
    private int currentSceneLoad;
    private void Awake(){
        currentSceneLoad=SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.GetComponent<PlayerControll>()!=null){
        SceneManager.LoadScene(currentSceneLoad);
        animator.SetBool("IsDead",true);
    }
    }
   
}

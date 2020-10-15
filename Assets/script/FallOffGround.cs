using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
public class FallOffGround : MonoBehaviour
{
    public Animator animator;
    [SerializeField]private GameOverController gameOver;
    private int currentSceneLoad;
    private void Awake(){
        currentSceneLoad=SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.GetComponent<PlayerControll>()!=null){
        
        animator.SetBool("IsDead",true);
        StartCoroutine(Wait());
    }
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(1);
        gameOver.PlayerDied();
    }
   
}

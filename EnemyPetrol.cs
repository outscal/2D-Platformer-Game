using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPetrol : MonoBehaviour
{
    [SerializeField] public float speed, distance;

    public Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    private bool movingRight = true;

    public Transform grounddetect;

    //Movement Of Enemy     
    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundinfo  = Physics2D.Raycast(grounddetect.position,Vector2.down,distance);
        if(groundinfo.collider == false ) {
            
            if(movingRight) {
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;
                anim.SetBool("Walk",true);
                
            }

            else {
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
                anim.SetBool("Walk",true);
            }
        }

    }
}
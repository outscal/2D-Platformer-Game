using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool directionRight= true;
    PlayerController pc;
    private void OnCollisionEnter2D(Collision2D collision) {
        pc= collision.gameObject.GetComponent<PlayerController>();
        if(pc!=null)
        {
            pc.TakeDamage();
        }
    }
    float setTime;
    private void OnCollisionStay2D(Collision2D collision) {
        //checking end of platform for turning around the enemy
        if(collision.gameObject.CompareTag("Platform"))
        {
            float Timer = Time.time;
            if(collision.contactCount<4&&Timer>=setTime)
            {
                directionRight= !directionRight;
                setTime=Timer+1;
            }
        }
    }
    void Update() 
    {
        Vector3 scale= transform.localScale;
        if(directionRight)
        {
        transform.position= transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        scale.x=1;
        }
        else
        {
        transform.position= transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        scale.x=-1;
        }
        transform.localScale= scale;
    }
}

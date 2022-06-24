using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float raylenght;
    public float moveSpeed;
    private bool moveRight;
    

    public Transform contactChecker;
    // Start is called before the first frame update
    void Start()
    {
        moveRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private  void FixedUpdate()
    {
        int layerMask = 1 << 7;
        layerMask = ~layerMask;

        RaycastHit2D contactCheck = Physics2D.Raycast(contactChecker.position, Vector2.left, raylenght, layerMask);
        Debug.DrawRay(contactChecker.position, Vector2.right * raylenght, Color.red);

        if (contactCheck == true)
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                moveRight = true;
            }
        }
    }
}

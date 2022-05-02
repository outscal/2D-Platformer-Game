using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{


     //public float speed = 0f;
    public Animator movementanimator;
    // Start is called before the first frame update
    void Start()
    {
        movementanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        movementanimator.SetFloat("speed", Mathf.Abs(horizontalMovement));
        Debug.Log(horizontalMovement);
        Vector2 scale = transform.localScale;
        if (horizontalMovement < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (horizontalMovement > 0)
            scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}

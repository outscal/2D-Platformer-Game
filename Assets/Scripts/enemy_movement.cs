using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField]
    private Transform point_a;
    [SerializeField] 
    private Transform point_b;
    private float step = 0;
    [SerializeField]
    private float speed=10;
    private float reverse_speed;

    public bool start_a=true;


    // Start is called before the first frame update
    void Start()
    {
        if (start_a == true)
        {
            transform.position = point_a.position;
            reverse_speed = -speed;
            Vector2 localScale = transform.localScale;
            localScale.x =-1;
            transform.localScale = localScale;
        }
        else
        {
            transform.position = point_b.position;
            reverse_speed = speed;
            Vector2 localScale = transform.localScale;
            localScale.x = -1;
            transform.localScale = localScale;
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        step = step + speed* Time.deltaTime;
        Debug.Log(step);
        if(step>=1)
        {
            speed = reverse_speed;
            Vector2 localScale = transform.localScale;
            localScale.x = 1;
            transform.localScale = localScale;
        }
        if(step<=0)
        {
            speed = -reverse_speed;
            Vector2 localScale = transform.localScale;
            localScale.x = -1;
            transform.localScale = localScale;
        }
        transform.position = Vector2.Lerp(point_a.position, point_b.position, step);
    }

    public void flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatforms : MonoBehaviour
{
    public bool hroizontal;
    public bool vertical;
    private int speed=1;
    public float  distanceToMove;
    float  distance;
    Vector3 staringPos;

    void Start()
    {
        staringPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(hroizontal)
        {
            distance = Mathf.Abs( staringPos.x - transform.position.x);
            if (distanceToMove < distance)
                speed *= -1;
            transform.Translate(new Vector3(speed, 0, 0)*Time.deltaTime);

        } if(vertical)
        {
            distance = Mathf.Abs( staringPos.y - transform.position.y);
            if (distanceToMove < distance)
                speed *= -1;
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}

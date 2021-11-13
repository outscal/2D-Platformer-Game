using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAi : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float waittime;
    public float starttime;
    public Transform[] movespot;
    private int randomspot;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        waittime = starttime;
        randomspot = Random.Range(0, movespot.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movespot[randomspot].position, speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, movespot[randomspot].position, speed * Time.deltaTime);
        // if (Vector2.Distance(transform.position, movespot[randomspot].position) < 0.2f)
        if (Vector2.Distance(transform.position, movespot[0].position) < 0.2f)
        {

            if (waittime <= 0)
            {
                randomspot = Random.Range(0, movespot.Length);
                waittime = starttime;
                sr.flipX = false;
            }
            else
            {
                waittime -= Time.deltaTime;

            }

        }
        else if (Vector2.Distance(transform.position, movespot[1].position) < 0.2f)
        {

            if (waittime <= 0)
            {
                randomspot = Random.Range(0, movespot.Length);
                waittime = starttime;
                sr.flipX = true;
            }
            else
            {
                waittime -= Time.deltaTime;

            }

        }
    }
}


using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private int turnPointPlayer = 19;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x += speed * Time.fixedDeltaTime;
        transform.position = position;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == turnPointPlayer)
        {
            speed = -1f * speed;
        }
        
    }
}

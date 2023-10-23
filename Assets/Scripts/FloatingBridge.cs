using UnityEngine;

public class FloatingBridge : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform[] floatingPoints;
    [SerializeField]
    private int speed;
    private Transform currenpoint;
    private bool isPlayerOnBridge;
    private void Start()
    {
        currenpoint = floatingPoints[0].transform;
    }
    private void FloatingBetweenPoints(int CP, int TP)
    {
        if (currenpoint == floatingPoints[CP])
        {
            // move towrds = from poistion a to position b with what speed 
            transform.position = Vector2.MoveTowards(transform.position, floatingPoints[CP].transform.position, speed * Time.deltaTime);
            
            // distance = distance btw pointa and point b (using transform)  
            if (Vector2.Distance(transform.position, floatingPoints[CP].transform.position) < 0.2f)
            {
                currenpoint = floatingPoints[TP];
            }
        }
    }
    private void FixedUpdate()
    {
        // Check if the player is on the bridge.
        if (isPlayerOnBridge && player != null)
        {
            // Calculate the offset between the bridge and the player.
            Vector3 offset = player.position - transform.position;

            Vector3 pos = player.position;
            pos.x = transform.position.x + offset.x * speed * Time.deltaTime;
            player.position = pos;

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnBridge = true;
            player = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnBridge = false;
            player = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(floatingPoints[0].position, 0.5f);
        Gizmos.DrawWireSphere(floatingPoints[1].position, 0.5f);
        Gizmos.DrawLine(floatingPoints[0].position, floatingPoints[1].position);
    }
    private void Update()
    {
        FloatingBetweenPoints(0,1);
        FloatingBetweenPoints(1,0);
    }
}

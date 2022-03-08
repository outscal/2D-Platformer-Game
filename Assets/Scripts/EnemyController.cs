using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool moveRight=true;
    [SerializeField] private Transform groundDetection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            HealthController playerHealthController = collision.gameObject.GetComponent<HealthController>();
            playerHealthController.PlayerTakeDamage();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (groundInfo.collider == false)
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }
}

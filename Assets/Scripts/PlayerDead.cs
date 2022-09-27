
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    float xPos;
    public Transform player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        xPos = player.position.x;
        transform.position = new Vector2(xPos, transform.position.y);
    }
}

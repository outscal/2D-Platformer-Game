using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision: " + collision.gameObject.name);
    }
}

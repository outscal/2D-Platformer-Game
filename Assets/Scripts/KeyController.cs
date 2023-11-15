using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<PlayerController>() != null)
        {
            other.GetComponent<PlayerController>().UpdateScore();
            Destroy(gameObject);
        }
    }
}

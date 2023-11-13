using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            print("h1");
            playerController.UpdateScore();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            print("h2");
            playerController.UpdateScore();
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            playerController.UpdateScore();
            gameObject.SetActive(false);
        }
    }
}

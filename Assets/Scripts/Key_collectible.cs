using UnityEngine;

public class Key_collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerController playercollision))
        {
            playercollision.updateScore();
            Destroy(gameObject);
            Debug.Log(playercollision.gameObject.name + "collected");
        }
    }
}
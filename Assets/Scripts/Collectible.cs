using UnityEngine;

public class Collectible : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 5f, 0, Space.World);
    }

	void OnTriggerEnter2D(Collider2D other) {

        other.gameObject.GetComponent<PlayerController>().Pickup();
		Destroy(gameObject);
	}
}

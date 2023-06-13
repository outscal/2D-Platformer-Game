using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5f, 0, Space.World);
    }

	void OnTriggerEnter2D(Collider2D other) {

        other.gameObject.GetComponent<PlayerController>().Pickup();
		Destroy(gameObject);
	}
}

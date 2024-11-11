using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float fadeSpeed = 100f;      // Speed at which the key fades out
    public float moveUpSpeed = 100f;    // Speed at which the key moves upward after collection
    private bool isCollected = false; // Flag to check if the key has been collected

    private void Update()
    {
        // If the key has been collected
        if (isCollected)
        {
            // Move the key upward
            transform.position += Vector3.up * moveUpSpeed * Time.deltaTime;

            // Get the current color of the key's SpriteRenderer
            Color keyColor = GetComponent<SpriteRenderer>().color;

            // Reduce the alpha value (transparency) to fade the key out
            keyColor.a -= fadeSpeed * Time.deltaTime;

            // Apply the updated color back to the key's SpriteRenderer
            GetComponent<SpriteRenderer>().color = keyColor;

            // If the key is fully faded out (alpha value is 0 or less)
            if (keyColor.a <= 0)
            {
                // Destroy the key object, removing it from the game scene
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            // Call the player's PickUpKey method
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            playerMovement.PickUpKey();

            // Set the isCollected flag to true to start the fade-out and move-up animation
            isCollected = true;

            // You can remove the Destroy(gameObject) line here, as it's now handled in the Update method after fading out
        }
    }
}

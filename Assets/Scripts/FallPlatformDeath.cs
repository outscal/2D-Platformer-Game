using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FallPlatformDeath : MonoBehaviour
{
    public GameObject gameOverUI; // Reference to the GameOverController
    public TextMeshProUGUI warningText; // Reference to the TextMeshPro message
    public Transform respawnPoint; // Set the respawn location
    private int fallCount = 0;

    private void Start()
    {
        // Ensure the warning message is hidden at the start
        warningText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //gameOverUI.SetActive(true);

        if (fallCount == 0)
        {
            // First fall: Respawn player and show warning
            fallCount++;
            warningText.text = "Player can fall only once!";
            other.transform.position = respawnPoint.position; // Respawn player
            StartCoroutine(ShowWarning());
        }
        else
        {
            // Second fall: Show Game Over UI
            gameOverUI.SetActive(true);
            other.gameObject.SetActive(false); // Disable player character
        }
    }

    private IEnumerator ShowWarning()
    {
        warningText.gameObject.SetActive(true); // Show warning
        yield return new WaitForSeconds(3f); // Display message for 3 seconds
        warningText.gameObject.SetActive(false); // Hide warning
    }
}

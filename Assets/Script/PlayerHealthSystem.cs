using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int startingHealth = 3;
    private int currentHealth;

    [Header("UI Components")]
    [SerializeField] private GameObject[] hearts;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("Components")]
    [SerializeField] private Player_Controller playerController;

    private void Awake()
    {
        currentHealth = startingHealth;
        UpdateHearts();
    }
    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        UpdateHearts();

        if (currentHealth <= 0)
        {
            PlayerKilled();
        }
    }
    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            currentHealth = 0;
            UpdateHearts();
            PlayerKilled();
        }
    }
    private void PlayerKilled()
    {
        StartCoroutine(ShowGameOver());
    }
    private IEnumerator ShowGameOver()
    {
        if (playerController != null)
        {
            Rigidbody2D rb = playerController.GetRigBody();
            if (rb != null)
            {
                rb.simulated = false;
            }
            playerController.enabled = false;
        }
        yield return new WaitForSeconds(0f);
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

    }
}
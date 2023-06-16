using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Image heartImagePrefab;
    [SerializeField] private Transform heartsContainer;
    private PlayerController playerController;
    private int currentHealth;
    [SerializeField] private float heartSpace;

    private void Start()
    {
        playerController = transform.root.GetComponent<PlayerController>();
        if (playerController != null)
        {
            currentHealth = playerController.GetHealth();
            UpdateHealthDisplay();
        }

    }

    public void UpdateHealthDisplay()
    {
        if (playerController != null)
        {
            currentHealth = playerController.GetHealth();
        }
        foreach (Transform child in heartsContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < currentHealth; i++)
        {
            Image heartImage = Instantiate(heartImagePrefab, heartsContainer);
            heartImage.transform.localPosition = new Vector3(i * heartSpace, 0f, 0f);
        }
    }
}

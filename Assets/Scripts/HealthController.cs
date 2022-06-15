using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private float health;
    private void Awake()
    {
        healthText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        health = 50;
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshUI();
    }
    public void UpdateHealth(float amount)
    {
        health += amount;
    }
    private void RefreshUI()
    {
        healthText.text = "Health: " + health.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    public HealthSystem playerHealth;
    public Image fillImage;
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if(slider.value > slider.minValue && !fillImage.enabled )
        {
            fillImage.enabled = true;
        }
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;
        if(fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.white;
        }
        else if(fillValue > slider.maxValue /3)
        {
            fillImage.color = Color.red;
        }
        slider.value = fillValue;
    }
}

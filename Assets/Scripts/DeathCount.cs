using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{   
    private TextMeshProUGUI deaths;
    private void Awake()
    {
        deaths = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUI();
    }
    public void PlayerDied() {
        PlayerPrefs.SetInt("Deaths",PlayerPrefs.GetInt("Deaths")+1);
        RefreshUI();
    }

    private void RefreshUI()
    {
        deaths.text = "Deaths: " + PlayerPrefs.GetInt("Deaths");

    }
}

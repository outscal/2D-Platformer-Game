using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCount : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI deaths;
    private static int deathcount=0;
    private void Awake()
    {
        //PlayerPrefs.SetInt("Deaths", 0);
    }
    private void Start()
    {
        RefreshUI();
    }
    public void PlayerDied() {
        deathcount++;
        RefreshUI();
    }

    private void RefreshUI()
    {
        deaths.text = "Deaths: " + deathcount;
    }
    /*private void OnDisable()
    {
        PlayerPrefs.DeleteAll();
    }*/
}

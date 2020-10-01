using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpKeys : MonoBehaviour
{   
    private int keyscollected=0;
    private TextMeshProUGUI keys;

    private void Awake()
    {
        keys = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();
    }


    public void KeyPicked() {
        keyscollected += 1;
        RefreshUI();
    }

    private void RefreshUI()
    {
        keys.text = "Keys: "+ keyscollected;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTeleport : MonoBehaviour
{
    [SerializeField] GameObject PopUp;
    [SerializeField] GameObject telePoter;
    [SerializeField] ScoreController scoreCont;
   
    void Start ()
    {
        telePoter.SetActive(false);
        this.gameObject.SetActive(true);
        PopUp.SetActive(false);
    }
    void Update()
    {
        OpenTeleporter();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            PopUp.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            PopUp.SetActive(false);
        }
    }
     void OpenTeleporter()
     {
        int Key = scoreCont.WhatIskey();
        if(Key >= scoreCont.KeyToCompleteLevel)
        {
            Invoke(nameof(DisableDoor), 2f);
            
        }
     }
     void DisableDoor()
     {
        telePoter.SetActive(true);
        this.gameObject.SetActive(false);
        PopUp.SetActive(false);

     }
    
    
}

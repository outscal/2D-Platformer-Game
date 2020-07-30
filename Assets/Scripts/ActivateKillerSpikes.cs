using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKillerSpikes : MonoBehaviour
{
    public GameObject killerSpikes;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>()!=null)
        {
            killerSpikes.SetActive(true);
        }
    }
}

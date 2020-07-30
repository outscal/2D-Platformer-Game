using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePressurepad : MonoBehaviour
{
    public GameObject jumpingPad;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            jumpingPad.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            collision.gameObject.GetComponent<PlayerControler>().ReloadScene();
        }
    }
}

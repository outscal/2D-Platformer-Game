using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        playerController.PickUpKey();
        SoundManager.Instance.Play(Sounds.KeyCollect);
        Destroy(gameObject);
    }
}

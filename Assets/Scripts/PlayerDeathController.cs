using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathController : MonoBehaviour
{
    public PlayerController controller;

    public ParticleController playerDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
            controller.isDead = true;
            playerDeath.PlayEffect();
            controller.ReloadLevel();
        }
    }
}

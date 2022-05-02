using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public int enemyDamage;
    [SerializeField] private HealthController _healthController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Debug.Log("Player Colling");
            PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
            killPlayer();
            //playerController.playerDeathAnimation();
        }

    }

    void killPlayer()
    {
        _healthController.playerHealth = _healthController.playerHealth - enemyDamage;
        _healthController.UpdateHealth();
    }
}

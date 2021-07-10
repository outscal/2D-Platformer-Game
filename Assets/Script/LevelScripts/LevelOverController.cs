using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Elle2D
{
    public class LevelOverController : MonoBehaviour
    {
        public PlayerController player;
        private void OnTriggerEnter2D(Collider2D collison)
        {
            if (collison.gameObject.GetComponent<PlayerController>() != null)
            {
                    LevelManager.Instance.MarkCurrentLevelComplete();
                    player.nextSceneButtonImage.gameObject.SetActive(true);
            }
        }
    }
} 
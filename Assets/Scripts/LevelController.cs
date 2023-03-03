using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Player;

namespace Level {
    public class LevelController : MonoBehaviour
    {
        int MAIN_MENU_BUILD_INDEX = 0;
        int maxScenes = 6;
        [SerializeField] Button RestartButton;
        [SerializeField] Button MainMenuButton;
        private void OnTriggerEnter2D(Collider2D other) {
            // Check if Player is Colliding
            if (other.gameObject.GetComponent<PlayerController>() != null) {
                PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                if (this.transform.name == "LevelComplete") {
                    LoadNextLevel();
                } else if (this.transform.name == "LowerBound") {
                    playerController.GameOverMenu.SetActive(true);
                }
            }
        }

        public void LoadNextLevel() {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % maxScenes);
        }
        public void LoadMainMenu() {
            SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
        }

        public void ReloadLevel() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}


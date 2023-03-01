using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;

namespace Level {
    public class LevelController : MonoBehaviour
    {
        int maxLevels = 1;
        private void OnTriggerEnter2D(Collider2D other) {
            // Check if Player is Colliding
            if (other.gameObject.GetComponent<PlayerController>() != null) {
                if (this.transform.name == "LevelComplete") {
                    // Load Next Level
                    Debug.Log("Load Next Level. Level Complete.");
                    LoadNextLevel();
                } else if (this.transform.name == "LowerBound") {
                    // Load Current Level
                    Debug.Log("Load Current Level.");
                    ReloadLevel();
                }
            }
        }

        public void LoadNextLevel() {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % maxLevels);
        }

        public void ReloadLevel() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}


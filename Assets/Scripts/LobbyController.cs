using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Menu {
    public class LobbyController : MonoBehaviour
    {
        int LEVEL_ONE_BUILD_INDEX = 1;
        [SerializeField] Button PlayButton;
        [SerializeField] Button QuitButton;

        void PlayGame() {
            SceneManager.LoadScene(LEVEL_ONE_BUILD_INDEX);
        }

        void QuitApplication() {
            Debug.Log("Quitting....");
            Application.Quit();
        }

        private void Awake() {
            PlayButton.onClick.AddListener(PlayGame);
            QuitButton.onClick.AddListener(QuitApplication);
        }

    }
}


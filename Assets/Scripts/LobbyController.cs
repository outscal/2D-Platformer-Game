using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Menu {
    public class LobbyController : MonoBehaviour
    {
        [SerializeField] Button PlayButton;
        [SerializeField] Button QuitButton;
        [SerializeField] GameObject LevelSelect;

        void PlayGame() {
            LevelSelect.SetActive(true);
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


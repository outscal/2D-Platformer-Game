using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Level {
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] int CollectibleBonus = 10;
        int currentScore = 0;
        TextMeshProUGUI textMeshProUGUI;

        private void Awake() {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            RefreshScore();
        }

        public void IncrementScore() {
            currentScore += CollectibleBonus;
        }

        private void RefreshScore() {
            textMeshProUGUI.text = "Score : " + currentScore;
        }

    }
}


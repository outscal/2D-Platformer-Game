using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Level {
    public class HealthController : MonoBehaviour
    {
        int maxLives;
        public int healthLivesLeft;
        [SerializeField] Image[] hearts;
        [SerializeField] Sprite FullHeart;
        [SerializeField] Sprite EmptyHeart;
        private void Awake() {
            maxLives = hearts.Length;
            healthLivesLeft = maxLives;
        }

        private void Update() {

            for (int index = 0; index < hearts.Length; index++) {
                Image heartImg = hearts[index];
                heartImg.sprite = (index < healthLivesLeft) ? FullHeart : EmptyHeart;
            }
        }
    }

}

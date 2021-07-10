using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Elle2D
{
    public class LobbyControlller : MonoBehaviour
    {
        public string gameSceneName;
        public void onButtonClick()
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            SceneManager.LoadScene(gameSceneName);
        }
        public void QuitButton()
        {
            Debug.Log("Should Quit");
            Application.Quit();
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyControlller : MonoBehaviour
{
    public string gameSceneName;

    public void onButtonClick()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(gameSceneName);
    }

}

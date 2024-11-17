using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void PlayerDied()
    {
        gameObject.SetActive(true);
        AudioManager.Instance.Play(SoundType.GameOver);
    }

    public void ReloadGame()
    {
        AudioManager.Instance.Play(SoundType.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

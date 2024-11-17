using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleteController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public void NextLevel()
    {
        AudioManager.Instance.Play(SoundType.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Replylevel()
    {
        AudioManager.Instance.Play(SoundType.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToLobby()
    {
        AudioManager.Instance.Play(SoundType.ButtonClick);
        SceneManager.LoadScene("Lobby");
    }
}

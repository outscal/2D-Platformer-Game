using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ReloadGame()
    {
        AudioManager.Instance.Play(SoundType.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

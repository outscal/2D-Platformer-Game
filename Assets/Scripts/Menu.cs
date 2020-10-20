using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Level;
    public GameObject levelSelection;


    AudioSource audioSource;
    public AudioClip closesfx;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void play()
    {
        //SceneManager.LoadScene(Level);
        levelSelection.SetActive(true);
    }
    public void close()
    {
        audioSource.PlayOneShot(closesfx);
        levelSelection.SetActive(false);
        SceneManager.LoadScene("Menu");

    }
    public void Exit()
    {
        Application.Quit();
    }

    public void reset()
    {
        PlayerPrefs.DeleteAll();
        if (LevelManager.Instance.GetLevelStatus("1") == LevelStatus.Locked)
        {
            LevelManager.Instance.SetLevelStatus("1", LevelStatus.Unlocked);
        }
        if (audioSource.isPlaying == false)
        {
            SceneManager.LoadScene("Menu");

        }
    }
}

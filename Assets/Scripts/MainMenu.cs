using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject levelSelection;
    [SerializeField]
    private GameObject optionPanel;

    private void Start()
    {
        optionPanel.SetActive(false);
    }
    public void Options()
    {
        SoundManager.Instance.SFXSounds(SoundTypes.OnClick);
        optionPanel.SetActive(true);
    }
    public void Play()
   {
        SoundManager.Instance.SFXSounds(SoundTypes.OnClick);
        SceneManager.LoadScene(1);
   }

    public void Quit()
    {
        SoundManager.Instance.SFXSounds(SoundTypes.OnClick);
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Levels()
    {
        SoundManager.Instance.SFXSounds(SoundTypes.OnClick);
        levelSelection.SetActive(true);
    }

    public void Back()
    {
        SoundManager.Instance.SFXSounds(SoundTypes.OnClick);
        optionPanel.SetActive(false);
    }
}

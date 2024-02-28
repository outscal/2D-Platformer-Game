using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    private Button[] levelButton;

    private void Awake()
    {
        int levelPlayable = PlayerPrefs.GetInt("levelPlayable", 1);
        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 1 > levelPlayable)
                levelButton[i].interactable = false;
        }
    }
    public void LoadLevel(int leveltoload)
    {
        SoundManager.Instance.SFXSounds(SoundTypes.OnClick);
        SceneManager.LoadScene(leveltoload);        
    }

    public void BackButton()
    {
        SoundManager.Instance.SFXSounds(SoundTypes.OnClick);
        gameObject.SetActive(false);
    }
}

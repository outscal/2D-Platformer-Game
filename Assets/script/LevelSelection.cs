using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public AudioSource click;


    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
            if ( i + 2 > levelAt) lvlButtons[i].interactable = false; 
            click.Play();
        }
    }


}

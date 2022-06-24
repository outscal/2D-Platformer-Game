using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenue : MonoBehaviour

{
    [SerializeField]private AudioSource ButtonSoundEffect;

    public void StartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

   private void OnClick()
   {
         ButtonSoundEffect.Play();
   }
}

using UnityEngine;
using UnityEngine.SceneManagement;



public class Audio : MonoBehaviour
{
   
    public AudioClip playSfx;
    public AudioClip closeSfx;
    public AudioClip ExitSfx;
    public AudioClip resetSfx;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playSound()
    {
        audioSource.PlayOneShot(playSfx);

        //SceneManager.LoadScene(Level);
       
    }
    public void closeSound()
    {
        audioSource.PlayOneShot(closeSfx);

    }
    public void ExitSound()
    {
        audioSource.PlayOneShot(ExitSfx);

        
    }

    public void resetSound()
    {
        audioSource.PlayOneShot(resetSfx);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    public string level;

    public AudioClip portal;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("animator component missing From the gameobject");

            audioSource = gameObject.AddComponent<AudioSource>();

        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {/*
            audioSource.PlayOneShot(portal);
            LevelManager.Instance.markCurrentlevelComplete();
            SceneManager.LoadScene(level);*/
            StartCoroutine("portalwait");

        }
    }

    IEnumerator portalwait()
    {
        audioSource.PlayOneShot(portal);
        yield return new WaitForSeconds(2f);
        
        LevelManager.Instance.markCurrentlevelComplete();
        SceneManager.LoadScene(level);

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public Animator animator;
    public int SceneID = 1;
    public float TimeDelay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log(" Level Finished by the Player ");
            Debug.Log(" Load New Level ");
            Invoke("LoadScene", TimeDelay);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneID);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string debugMsg;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the PlayerController script
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            Destroy(other.gameObject);

            Debug.Log(debugMsg);

            SceneManager.LoadScene(sceneName);
        }
    }
}

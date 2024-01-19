using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    //[SerializeField] PlayerLifeLineManager playerLifeLineManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            collision.GetComponent<PlayerLifeLineManager>().UpdateLifeLine();
        }

    }
}

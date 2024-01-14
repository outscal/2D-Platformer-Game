using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathOnFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Died! Restarting Level");
            StartCoroutine(DeathReload());
        }
    }

    IEnumerator DeathReload()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}

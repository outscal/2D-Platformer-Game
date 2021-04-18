using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public GameObject newLevelComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Player")) 
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //SceneManager.LoadScene(2);
            //level is over
            Debug.Log("Level Finished by Player");
            LevelManager.Instance.MarkCurrentLevelComplete();
            newLevelComplete.SetActive(true);
        }
    }
}

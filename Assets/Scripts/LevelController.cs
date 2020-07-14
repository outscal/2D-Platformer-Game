using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public string levelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if(other.gameObject.GetComponent<PlayerController>() !=null)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}

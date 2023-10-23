using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int leveltoUnlock = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            PlayerPrefs.SetInt("levelPlayable", leveltoUnlock);
            SceneManager.LoadScene(leveltoUnlock);
        }
    }

}

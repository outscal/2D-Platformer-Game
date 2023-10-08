using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int leveltoUnlock;
    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            UI_Manager.instance.LevelComplete();       
        }
    }

    public void ToNextLevel()
    {
        var scene = SceneManager.GetActiveScene().buildIndex;
        leveltoUnlock = scene + 1;
        PlayerPrefs.SetInt("levelPlayable", leveltoUnlock);
        SceneManager.LoadScene(leveltoUnlock);
        Debug.Log("Level unlocked " + leveltoUnlock);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameOverUI;
    public void gameOver()
    {
        //gameOverUI.SetActive(true);
        SceneManager.LoadSceneAsync(1);

    }
}

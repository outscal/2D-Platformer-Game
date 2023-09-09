using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOver_Panel;
    [SerializeField]
    private GameObject Main_Menu;
    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GameOver_Panel.SetActive(false);
        Main_Menu.SetActive(true);
    }

    public void Play_Button()
    {
        Main_Menu.SetActive(false);
        
    }
    private void IsPlayerDead()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player.transform.position.y <= -34)
        {
            GameOver_Panel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameOver_Panel.SetActive(false);
                var scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    private void Update()
    {
        IsPlayerDead();
    }
}

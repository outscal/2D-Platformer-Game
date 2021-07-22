using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPointScript : MonoBehaviour
{
    public GameObject DeathPanel;
    public Button btnRestartGame;
    // Start is called before the first frame update
    void Start()
    {
        btnRestartGame.onClick.AddListener(ReloadScene);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is dead");
            DeathPanel.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void ReloadScene()
    {
        DeathPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public PlayerController playercontroller;
    PlayerHealthManager phm;

    public Animator anim;
    private void Start()
    {

        playercontroller.respawnPoint = playercontroller.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            health = health - 1;
            playercontroller.transform.position = playercontroller.respawnPoint;     

        }
    }

    void Update()
    {
        foreach ( Image img in hearts )
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;

        }
        if(health<1)
        {
            Debug.Log("player died");
            SceneManager.LoadScene("Lobby");
            

        }
    }
}

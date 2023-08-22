﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonReplay;
    public Button buttonExit;
    public GameObject GameOvermenu;
    public Animator animator;
    PlayerController playerController;


    void Awake()
    {
        buttonReplay.onClick.AddListener(ReplayLevel);
        buttonExit.onClick.AddListener(ExitToLobby);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player Fall Dead");
            animator.SetBool("Death", true);
            PlayeDied();           
        }
        else
        {
            animator.SetBool("Death", false);
        }
    }

    public void PlayeDied()
    {
        GameOvermenu.SetActive(true);
    }

    private void ReplayLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    private void ExitToLobby()
    {
        SceneManager.LoadScene(0);
    }
}

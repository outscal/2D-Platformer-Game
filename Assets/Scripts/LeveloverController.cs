using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LeveloverController : MonoBehaviour
{
    private bool reset;
    private UIManager _uimanager;
    
    private void Awake()
    {
        reset = false;
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Start()
    {
        if (_uimanager == null)
        {
            Debug.LogError("The UIMnager is null");
        }
    }
    private void Update()
    {
        if(reset)
        {
            reload();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Playercontroller>() !=null)
        {
            Debug.Log("End of the Game");
            _uimanager.gameStatus();
            reset = true;
          
        } 
    }

 
    private void reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }else if(Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}

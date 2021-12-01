using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LeveloverController : MonoBehaviour
{
    private bool reset;
    private UIManager _uimanager;
    public int nextSceneLoad;

    private void Awake()
    {
        reset = false;
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
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
        Playercontroller player = collision.GetComponent<Playercontroller>();
        if (player != null)
        {
            Debug.Log("End of the Game");
            _uimanager.gameStatus();
            StartCoroutine("setTrueLevelCompleted");
            Time.timeScale = 0;


        } 
    }

    IEnumerator setTrueLevelCompleted()
    {
        
        while(!reset)
        {
            yield return new WaitForSecondsRealtime(2.0f);
            reset = true;
            

        }

    }

    private void reload()
    {
       
        //Move to next level
        SceneManager.LoadScene(nextSceneLoad);

        //Setting Int for Index
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }


}

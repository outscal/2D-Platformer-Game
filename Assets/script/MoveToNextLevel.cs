using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MoveToNextLevel : MonoBehaviour
{
    public int nexSceneLoad;
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI m_Object;
    [SerializeField] private AudioSource nxtlvl;

    void Start()
    {
        nexSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            

            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                Debug.Log("you win the game");
                m_Object.text = "You win !!!!!!!!!";
                 //Time.timeScale = 0;
                // Invoke("ReloadLevel()", .5f);

                
            }
            else 
            {
                SceneManager.LoadScene(nexSceneLoad);          // move to next level


                if (nexSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    nxtlvl.Play();
                    PlayerPrefs.SetInt("levelAt", nexSceneLoad);
                }
            }
            
           
        }   

    }

}

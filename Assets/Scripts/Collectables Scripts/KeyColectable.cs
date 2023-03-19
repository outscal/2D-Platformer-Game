using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyColectable : MonoBehaviour
{
    public KeyAnimation keyAnim;

   

    private void Awake()
    {
        
       // keyAnim = GameObject.FindGameObjectWithTag("Key").GetComponent<KeyAnimation>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            keyAnim.SetFlag(true);
           // this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<PlayerController>().KeyCollected();
           
         
            
           // Destroy(gameObject,1);
          //  UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // what is better Destroy OR Setting Deactivate Why ? and wehen to use them ?
            // Deatcivate is only Useful when we need that object Agian in Our Scene  For Excample pooling Of Obstacles ,Enemy Etc. Right ?
            // Destroy when we don't need the object again  in Our scene . Right ?

            // Please let me know if other use cases are there 
        }
    }

   
        
   


    // why OIenurator don't working with destroy fucntion  , Why it's not destroying asftedr the time of Ienumeraot?

    // How to give eas ein and eas eout efefct?

}

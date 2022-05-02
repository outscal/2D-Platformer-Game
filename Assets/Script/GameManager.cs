using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    
    
    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
    

    
}

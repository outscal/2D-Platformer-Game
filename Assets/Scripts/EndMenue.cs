using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenue : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        SceneManager.LoadScene("Start Screen");
       
    }
}

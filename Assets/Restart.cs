using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{



    public void RestartGame()
    {
        // Reload the game scene (assuming it's the first scene in the build settings)
        SceneManager.LoadScene(1);
    }
}



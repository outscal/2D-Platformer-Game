using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour

{
    public void QuitGame()
    {
        // Quit the application (works in standalone builds, not in the Unity Editor)
        Application.Quit();
    }
}



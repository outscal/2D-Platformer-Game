using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
   public void level2()
    {
        SceneManager.LoadSceneAsync(3);
    }
}

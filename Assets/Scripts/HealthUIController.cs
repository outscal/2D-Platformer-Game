using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthUIController : MonoBehaviour
{
    // Start is called before the first frame update

   
    void Start()
    {
    }

    public void LivesDisplayUpdate(int lives)
    {
        Debug.Log("Lives" + lives); 
        transform.GetChild(lives).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Player player; 

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log(" GameManager Instance is NULL");
            }
            return _instance;
        }
    }
    public void Awake()
    {
        _instance = this;

    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

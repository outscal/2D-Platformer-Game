using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManage : MonoBehaviour
{
    public static LevelManage Instance{ get; private set; }

    public int levelStatus;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

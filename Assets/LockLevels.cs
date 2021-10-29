using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LockLevels : MonoBehaviour
{
    public Button[] btns;
    
    private void Awake()
    {
        foreach (Button x in btns) x.interactable = false;
        
        for (int i = 0; i < btns.Length; i++)
        {
            if (i < LevelManage.Instance.levelStatus)
                btns[i].interactable = true ;
        }
    }
}

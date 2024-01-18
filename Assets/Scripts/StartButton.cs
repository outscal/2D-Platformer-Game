using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject ToEnable;

    public void EnableObject()
    {
        ToEnable.SetActive(true);
    }

}

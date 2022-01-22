using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerprefs : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

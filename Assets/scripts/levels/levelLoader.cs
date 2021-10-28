using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class levelLoader : MonoBehaviour
{
    Button btn;
    public string levelName;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneManager.LoadScene(levelName);
    }
}

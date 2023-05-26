using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Level_select_button : MonoBehaviour
{
    private Button button;
    public int level;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    public void onClick()
    {
        SceneManager.LoadScene(level);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    public Button LoadButton;

    public string LevelName;

    private void Awake()
    {
        LoadButton.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {
        LevelManager.Instance.LoadAnyLevel(LevelName);
    }
}
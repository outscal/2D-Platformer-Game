using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button LoadButton;

    public string LevelName;

    private void Awake()
    {
        LoadButton = GetComponent<Button>();
        LoadButton.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {
        LevelManager.Instance.LoadAnyLevel(LevelName);
    }
}
using UnityEngine;
using TMPro;

public class LevelSelectionTextController : MonoBehaviour
{
    private TextMeshProUGUI levelSelectionText;

    private void Awake()
    {
        levelSelectionText = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayLockedText()
    {
        levelSelectionText.text = "Level is Locked. Complete Previous Level to unlock.";
        Invoke("ClearDisplayedText", 0.5f);
    }

    private void ClearDisplayedText()
    {
        levelSelectionText.text = "";
    }
}

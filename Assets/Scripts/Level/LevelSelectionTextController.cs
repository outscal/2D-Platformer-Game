using UnityEngine;
using TMPro;
using System;

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
        Invoke("ClearDisplayedText", 2);
    }

    private void ClearDisplayedText()
    {
        levelSelectionText.text = "";
    }
}

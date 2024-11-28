using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public GameObject levelSelectionPopup;

  
    public void ShowLevelSelectionPopup()
    {
        levelSelectionPopup.SetActive(true); // Show the popup
    }

    // Call this method when the level selection is cancelled or done
    public void HideLevelSelectionPopup()
    {
        levelSelectionPopup.SetActive(false); // Hide the popup
    }
}

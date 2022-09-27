
using UnityEngine;
using TMPro;


public class UI_text : MonoBehaviour{

    public TextMeshProUGUI scoreUI;

    private void Awake()
    {
        scoreUI = GetComponent<TextMeshProUGUI>();
        scoreUI.text = "score : 0";
    }
}
  
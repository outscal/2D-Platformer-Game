using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsManager : MonoBehaviour {

    private int hearts = 3;

    public void SetHearts(int h) {
        hearts = h;
        UpdateHeartsText();
    }

    private void UpdateHeartsText() {
        GetComponent<Text>().text = "Hearts : " + hearts;
    }
}

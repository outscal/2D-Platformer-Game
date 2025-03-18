using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum LevelUIWindow
{
    GAME_OVER,
    GAME_FINISH
}

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI CollectablesCount;
    public TextMeshProUGUI LevelNum;

    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private GameObject gameFinishWindow;

    [SerializeField] GameManagerScript gameManagerScript;

    private void Start()
    {
        
    }

    public void CollectablesCountUpdate(int count)
    {
        CollectablesCount.text = "Keys = " + count;
    }

    public void LevelNumberUpdate(int levelNumber)
    {
        LevelNum.text = "Level: " + levelNumber;
    }

    public void ToggleLevelUI(LevelUIWindow window, bool choice)
    {
        switch(window)
        {
            case LevelUIWindow.GAME_OVER:
                gameOverWindow.SetActive(choice);
                break;
            case LevelUIWindow.GAME_FINISH:
                gameFinishWindow.SetActive(choice);
                break;
        }
    }

    public void OnButtonClick(int buttonNum)
    {
        gameManagerScript.LoadScene((SceneNumber)buttonNum);
    }
}
/*int FuncB()
 * int b = gameManagerScript.FuncA();
 * return a;
 */
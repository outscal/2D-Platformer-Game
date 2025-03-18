using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneNumber
{
    MAIN_MENU,
    CURRENT,
    NEXT
}

public class GameManagerScript : MonoBehaviour
{
    public static bool[] levelUnlock = new bool[4]; 

    [SerializeField] private CanvasScript canvasScript;


    private int CollectablesCount = 0;
    private int LevelNumber;

    private void Start()
    {
        LevelNumber = SceneManager.GetActiveScene().buildIndex;
        canvasScript.LevelNumberUpdate(LevelNumber);
        canvasScript.ToggleLevelUI(LevelUIWindow.GAME_OVER, false);
        canvasScript.ToggleLevelUI(LevelUIWindow.GAME_FINISH, false);
    }

    public void OnLevelComplete()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings - 1;
        if(currentSceneIndex < levelUnlock.Length)
            levelUnlock[currentSceneIndex] = true;
        if (currentSceneIndex != totalScenes)
        {
            LoadScene(SceneNumber.NEXT);
        }
        else
        {
            Debug.Log("You have finished the game!");
            canvasScript.ToggleLevelUI(LevelUIWindow.GAME_FINISH, true);
        }
    }

    public void LoadScene(SceneNumber sceneNum)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneNum)
        {
            case SceneNumber.MAIN_MENU:
                SceneManager.LoadScene(0);
                break;
            case SceneNumber.CURRENT:
                SceneManager.LoadScene(currentSceneIndex);
                break;
            case SceneNumber.NEXT:
                SceneManager.LoadScene(currentSceneIndex + 1);
                break;
        }
    }

    public void KillPlayer()
    {
        Debug.Log("You died!");
        canvasScript.ToggleLevelUI(LevelUIWindow.GAME_OVER ,true);
    }

    public void IncreaseCount(int CountIndex)
    {
        switch(CountIndex)
        {
            case 0:
                CollectablesCount++;
                canvasScript.CollectablesCountUpdate(CollectablesCount);
                break;
        }
        
    }
}



/*int FuncA()
 * int a = canvasScript.FuncB();
 * return a;
 */

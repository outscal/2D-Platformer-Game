using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
private Button button;
[SerializeField]private int levelIndex;
[SerializeField]private string levelName;

private void Awake(){
    button=GetComponent<Button>();
    button.onClick.AddListener(clickButton);
}
private void clickButton(){
    Levels levelStatus=LevelManager.Instance.GetLevelStatus(levelName);
    switch(levelStatus){
        case Levels.locked:
        //Debug.Log("Level is locked can't play");
        break;
        case Levels.unLocked:
        SceneManager.LoadScene(levelIndex);
        break;
        case Levels.completed:
        SceneManager.LoadScene(levelIndex);
        break;
    }
    
}
}

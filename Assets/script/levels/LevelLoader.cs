using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
private Button button;
[SerializeField]
private int levelIndex;
private void Awake(){
    button=GetComponent<Button>();
    button.onClick.AddListener(clickButton);
}
private void clickButton(){
    SceneManager.LoadScene(levelIndex);
}
}

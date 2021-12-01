using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionController : MonoBehaviour
{
    [SerializeField]
    public Button[] levelBtns;
    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2); 
        for (int i = 0; i < levelBtns.Length; i++)
        {
                 if (i + 2 > levelAt)
                levelBtns[i].interactable = false;
        }
    }

    
    public void ChangeScene(int sceneIndex)
    {
        
        Debug.Log("sceneName to load: " + sceneIndex);
        // SceneManager.LoadScene(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }
    public void deletePref()
    {
        PlayerPrefs.DeleteAll();
    }
    

}

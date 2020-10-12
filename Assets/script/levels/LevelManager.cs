using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
private static LevelManager instance;
public static LevelManager Instance{get {return instance;}}

public string [] levels;
private void Awake(){
    if(instance==null){
        instance=this;
        DontDestroyOnLoad(gameObject);
    }
    else 
    Destroy(gameObject);
}
private void Start(){
    if(GetLevelStatus(levels[0])==Levels.locked)
    {
        SetLevelStatus(levels[0],Levels.unLocked);
    }
}
public void MarkCurrentLevelComplete(){
    Scene currentScene=SceneManager.GetActiveScene();
    SetLevelStatus(currentScene.name,Levels.completed);
    int currentScneIndex =Array.FindIndex(levels,level=>level ==currentScene.name);
    int nextSceneIndex=currentScneIndex+1;
    if(nextSceneIndex<levels.Length){
        SetLevelStatus(levels[nextSceneIndex],Levels.unLocked);

    }

}
public Levels GetLevelStatus(string level){
Levels levelStatus=(Levels) PlayerPrefs.GetInt(level,0);
return levelStatus;
}
public void SetLevelStatus(string level,Levels levelStatus){
    PlayerPrefs.SetInt(level,(int)levelStatus);
    //Debug.Log("setting level "+level +" status "+levelStatus);
}
}

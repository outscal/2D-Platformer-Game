using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lives_system : MonoBehaviour
{
    public static Image[] lives=new Image[3];
    
    public static int lives_counter = 3;
    private static int max_lives=3;
    // Start is called before the first frame update


    public static void lives_increase()
    {
        lives_counter=lives_counter<3?lives_counter++:lives_counter;
    }

    public static void lives_decrease() 
    {
        //Debug.Log(lives_counter);
        if(lives_counter==1)
        {
            SceneManager.LoadScene(1);
        }
        //lives_counter = 3;
        lives_counter = lives_counter > 1 ? --lives_counter : 0;
        load_lives();
    }
    public static void restore_counter()
    {
        lives_counter = max_lives;
    }

    public static void load_lives()
    {
        lives[0] = GameObject.Find("1_health").GetComponent<Image>();
        lives[1] = GameObject.Find("2_health").GetComponent<Image>();
        lives[2] = GameObject.Find("3_health").GetComponent<Image>();
        for (int i=2;i>=0;i--)
        {
            lives[i].enabled = false;
        }
        for(int i=0;i<lives_counter;i++)
        {
            lives[i].enabled = true;
        }
    }
}

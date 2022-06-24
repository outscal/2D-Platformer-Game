using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;

    [SerializeField]private AudioSource KeyCollectSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score : " + ScoreNum;
    }

 private void OnTriggerEnter2D(Collider2D Key)

    {
       if (Key.tag == "Key")
       {
           ScoreNum += 1;
           Destroy(Key.gameObject);
           KeyCollectSoundEffect.Play();
           MyscoreText.text = "Score : " + ScoreNum;
       }
   } 
      
  
}

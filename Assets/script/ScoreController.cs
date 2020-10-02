using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
 private TextMeshProUGUI scoreText;
 private int score=0;
 private void Awake(){
     scoreText=GetComponent<TextMeshProUGUI>();
 }
 private void Start(){
     RefreshUI();
 }
 public void IncreaseScore(int newScore){
     score+=newScore;
     RefreshUI();
 }
 private void RefreshUI(){
     scoreText.text="Score : "+score;
 }
}

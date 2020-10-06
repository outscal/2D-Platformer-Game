using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button button;
    private void Awake(){
        button.onClick.AddListener(PlayGame);  
     }
     private void PlayGame(){
         SceneManager.LoadScene(1);
     }
}

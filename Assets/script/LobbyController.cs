using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject levelSelection;
    private void Awake(){
        button.onClick.AddListener(PlayGame);  
     }
     private void PlayGame(){
         SoundManager.Instance.PlaySound(Sounds.buttonClick);
         levelSelection.SetActive(true);
     }
}

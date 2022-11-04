
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level_Selector : MonoBehaviour
{
   public TextMeshProUGUI LevelText;

    public void Select_level()
    {
        SceneManager.LoadScene("Level_"+ LevelText.text);
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject levelSelection;
   public void Play()
   {
        SceneManager.LoadScene(1);
   }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Levels()
    {
        levelSelection.SetActive(true);
    }

}

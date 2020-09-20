using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3Button : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    private void OnButtonClick()
    {
        SceneManager.LoadScene("Scene3");
    }
}

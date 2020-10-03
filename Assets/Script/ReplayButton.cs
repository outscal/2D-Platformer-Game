using UnityEngine;
using UnityEngine.UI;


public class ReplayButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    private void OnButtonClick()
    {
        FindObjectOfType<GameManager>().resetGame();
    }
}

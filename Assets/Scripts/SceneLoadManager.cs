using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private int index = 0;

    public void ChangeScene() {
        SceneManager.LoadScene(index);
    }
}

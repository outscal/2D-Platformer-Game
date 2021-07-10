using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Elle2D
{
    //this class is for scene  button
    public class SceneLoderScript : MonoBehaviour
    {
        private Button button;
        public string sceneName;
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(onClick);
        }

        private void onClick()
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}

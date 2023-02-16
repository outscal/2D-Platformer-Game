using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameovercontroller : MonoBehaviour
{
    public HealthController HealthController;
    public Button RestartButton;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Health is " + HealthController.HealthCheck());
        if (HealthController.HealthCheck() <= 0)
        {
            gameObject.SetActive(true);
        }
        RestartButton.onClick.AddListener(Restart);
    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

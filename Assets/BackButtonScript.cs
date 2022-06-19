using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class BackButtonScript : MonoBehaviour
{   private  Button backButton;
    public GameObject toBeDeactivated;
    // Start is called before the first frame update
    void Awake()
    {
        backButton = GetComponent<Button>();
    }
    private void Start()
    {
        backButton.onClick.AddListener(GoBack);
    }

    private void GoBack()
    {
        toBeDeactivated.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

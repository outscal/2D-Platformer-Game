using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_to_menu : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetBool("Dead", true);
        lives_system.restore_counter();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }
}

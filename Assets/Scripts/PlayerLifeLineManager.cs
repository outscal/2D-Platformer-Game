using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeLineManager : MonoBehaviour
{
    [SerializeField] List<GameObject> lifelines;

    public void UpdateLifeLine()
    {
        Destroy(lifelines[lifelines.Count - 1]);
        lifelines.RemoveAt(lifelines.Count - 1);
        transform.position = Vector3.zero;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (lifelines.Count <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject particles;

    public void PlayEffect()
    {
        particles.SetActive(true);
        Invoke("StopEffect", 3f);
    }

    public void StopEffect()
    {
        particles.SetActive(false);
    }
}

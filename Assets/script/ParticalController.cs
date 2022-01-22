using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalController : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void PlayPlayerWinEffect()
    {
        particleSystem.Play();
    }
}

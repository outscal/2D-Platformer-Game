using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCOntroller : MonoBehaviour
{
    public new ParticleSystem particleSystem;

    public void PlayPlayerWin()
    {
        gameObject.SetActive(true);

    }
}

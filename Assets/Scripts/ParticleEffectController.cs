using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectController : MonoBehaviour
{
    public ParticleSystem particleEffect;

    public void PlayFailingLevel()
    {
        gameObject.SetActive(true);
        particleEffect.Play();
    }
}

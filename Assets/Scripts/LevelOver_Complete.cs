using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOver_Complete : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            SoundManager.Instance.LowVolSFXSounds(SoundTypes.Teleportation);
            SoundManager.Instance.loopinSounds.Stop();
            UI_Manager.Instance.LevelComplete();
        }
    }
}

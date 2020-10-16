using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject?.GetComponent<Player>();
        if ( player!= null)
        {
            SoundManager.Instance.Play(SoundList.ItemCollect); 
            Destroy(this.gameObject); 
            player.PickUpKey(); 
        }        
    }

}

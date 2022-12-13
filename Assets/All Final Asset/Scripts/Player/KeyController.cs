using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float Duration;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Collider2D Foodcollider2D;

    Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
   private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            
            Foodcollider2D.enabled = false;
            rb2D.velocity = transform.up * Time.deltaTime * speed;
            SoundManager.Instance.Play(Sounds.KeyPick);
            StartCoroutine("FadeOutAnimation");

            Destroy(gameObject,1f);
        }

    }
        private IEnumerator FadeOutAnimation()
        {
            float counter = 0;
            Color spriteColor = spriteRenderer.color;
            while(counter < Duration)
            {
                counter += Time.deltaTime;
                float alpha = Mathf.Lerp(1,0,counter);
                spriteRenderer.color = new Color(spriteColor.r,spriteColor.g,spriteColor.b,alpha);
                yield return null;
            }
        }
}

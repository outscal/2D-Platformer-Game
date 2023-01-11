using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private Animator anim;
    private SpriteRenderer _playerSprite;
    private BoxCollider2D player2d;

    private float m_scalex, m_scaley;
    private bool _isCrouching;
    // Start is called before the first frame update
    void Start()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
        player2d = GetComponent<BoxCollider2D>();

        if(_playerSprite == null)
        {
            Debug.Log("Player sprite not available");
        }

        m_scalex = 0.8645924f;
        m_scaley = 1.320639f;
    }

    // Update is called once per frame
    void Update()
    {

        MovementAnimation();
    }

    void MovementAnimation()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(horizontalInput));

        
        if(horizontalInput < 0)
        {
            _playerSprite.flipX = true;
        }
        else
        {
            _playerSprite.flipX = false;
        }

        
        if(Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("isCrouch", true);
            _isCrouching = true;
            player2d.offset = new Vector2(-0.09592718f, 0.6275121f);
            player2d.size = new Vector2(m_scalex, m_scaley);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("isCrouch", false);
            player2d.offset = new Vector2(-0.009804815f, 1.000709f);
            player2d.size = new Vector2(0.6518943f, 2.068996f);
        }


    }
}

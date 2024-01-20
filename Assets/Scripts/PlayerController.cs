using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator m_Animator;
    [SerializeField]
    private GameObject m_Player;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = m_Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxis("Horizontal");
        ControlHorizontalMovement(speed);
    }

    private void ControlHorizontalMovement(float speed)
    {
        if (m_Animator != null)
        {

            if (speed == 0) { return; }
            m_Animator.SetFloat("Speed", Mathf.Abs(speed));
            float scaleX = m_Player.transform.localScale.x;
            if (speed < 0)
            {
                scaleX = -1 * Mathf.Abs(scaleX);
            }
            else
            {
                scaleX = Mathf.Abs(scaleX);
            }
            m_Player.transform.localScale = new Vector3(scaleX, m_Player.transform.localScale.y, m_Player.transform.localScale.z);
        }
    }
}

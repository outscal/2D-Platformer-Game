using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elle2D
{
    public class MovingPlatform : MonoBehaviour
    {
        Vector3 moveDirection = Vector3.down;
        [SerializeField] float speed = 4f;
        [SerializeField] float timer = 3.5f;

        void Start()
        {
            StartCoroutine(ChangeDirection());
        }
        void Update()
        {
            MovePlatform();
        }

        void MovePlatform()
        {
            transform.Translate(moveDirection * speed * Time.smoothDeltaTime);
        }

        IEnumerator ChangeDirection()
        {
            yield return new WaitForSeconds(timer);
            if (moveDirection == Vector3.down)
            {
                moveDirection = Vector3.up;
            }
            else
            {
                moveDirection = Vector3.down;
            }

            StartCoroutine(ChangeDirection());
        }

    }

}
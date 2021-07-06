using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elle2D
{
    namespace Elle2D
    {
        public class Wepon : MonoBehaviour
        {
            public Transform firePoint;
            public GameObject bulletPrefab;
            [SerializeField] float timeuntillFire;
            [SerializeField] float fireRate = 0.2f;
            PlayerController playerMovement;

            private void Start()
            {
                playerMovement = gameObject.GetComponent<PlayerController>();
            }

            private void Update()
            {
                if (timeuntillFire < Time.time && playerMovement.withGun == true)
                {
                    Shoot();
                    timeuntillFire = Time.time + fireRate;
                }
            }

            void Shoot()
            {
                float angle = playerMovement.isFacingRight ? 0f : 180f;
                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            }
        }
    }
}
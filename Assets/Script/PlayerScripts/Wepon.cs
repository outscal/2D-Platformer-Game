using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Elle2D
{
    //this script for bullet  instantiating
    public class Wepon : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;
        private float timeuntillFire;
        [SerializeField] float fireRate = 0.2f;
        PlayerController playerMovement;

        Vector3 originalPos;
        Vector3 crouchFirePointPos;

        private void Start()
        {
            playerMovement = gameObject.GetComponent<PlayerController>();
            originalPos = firePoint.position;
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
            if (!playerMovement.crouch)
            {

                Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            }
            else if (playerMovement.crouch)
            {
                crouchFirePointPos = new Vector3(firePoint.position.x, originalPos.y - 1.5f, 0);
                Instantiate(bulletPrefab, crouchFirePointPos, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            }
        }

    }
}

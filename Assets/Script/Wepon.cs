using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    float timeuntillFire;
    PlayerController playerMovement;

    private void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        // if (Input.GetMouseButton(0) && timeuntillFire < Time.time && playerMovement.withGun==true )
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

        // Debug.Log("111");

        // RaycastHit2D hitInfo =  Physics2D.Raycast(firePoint.position,firePoint.right);
        // if (hitInfo)
        // {
        //     Debug.Log(hitInfo.transform.name);
        // }
        // Debug.DrawRay(firePoint.position);
    }
}

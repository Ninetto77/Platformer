using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireSpeed;

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position , Quaternion.identity);
        Rigidbody2D currentBulletSpeed = currentBullet.GetComponent<Rigidbody2D>();
        bool isRight = GetComponent<PlayerMoovement>().IsFlipRight;
        
        if (isRight)
        {
            currentBulletSpeed.velocity = new Vector2(1 * fireSpeed, currentBulletSpeed.velocity.y );
        }
        else
        {
            currentBulletSpeed.velocity = new Vector2(-1 * fireSpeed, currentBulletSpeed.velocity.y);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bullet;

    public void Shoot()
    {
        Instantiate(bullet, shootingPoint.position, transform.rotation);
    }
}

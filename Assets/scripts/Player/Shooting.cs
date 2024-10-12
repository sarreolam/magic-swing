using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private GameObject bulletToDestroy;
    private bool canShoot = true;
    public float fireRate;

    void Update()
    {
        if (Input.GetButton("Fire1")){
            if(canShoot){
                StartCoroutine(destroyBullet());
            }
        }
    }

    IEnumerator destroyBullet()
    {
        canShoot = false;
        bulletToDestroy = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation) ;
        Destroy(bulletToDestroy, 2);
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

}

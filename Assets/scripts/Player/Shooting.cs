using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private GameObject bulletToDestroy;
    private bool canShoot;
    public float fireRate;
    public AudioSource shooting;
    [SerializeField] Animator characterAnimator;

    void Start()
    {
        canShoot = true;
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (canShoot)
            {
                characterAnimator.SetTrigger("IsShot");
                StartCoroutine(destroyBullet());
                shooting.Play();
            }
        }
    }

    IEnumerator destroyBullet()
    {
        canShoot = false;
        bulletToDestroy = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        Destroy(bulletToDestroy, 2);
        yield return new WaitForSeconds(fireRate);
        canShoot = true;

    }

    public void setCanShoot(bool canShoot)
    {
        this.canShoot = canShoot;
        this.enabled = canShoot;
    }


}

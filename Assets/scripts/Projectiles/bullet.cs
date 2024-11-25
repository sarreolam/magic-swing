using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D bulletPrefab;

    void Start()
    {
        bulletPrefab = GetComponent<Rigidbody2D>();
        bulletPrefab.velocity = transform.right * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{
    public Transform firePoint;
    public GameObject kunaiPrefab;

    public float kunaiForce= 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        GameObject kunai= Instantiate(kunaiPrefab,firePoint.position, firePoint.rotation);
        Rigidbody2D rb= kunai.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * kunaiForce, ForceMode2D.Impulse);
    }
}

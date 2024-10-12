using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{
    public Transform firePoint;
    public GameObject kunaiPrefab;

    public float kunaiForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {   //The direction of the kunai follows the direction of the mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - firePoint.position).normalized;

        GameObject kunai = Instantiate(kunaiPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = kunai.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * kunaiForce, ForceMode2D.Impulse);
    }
}

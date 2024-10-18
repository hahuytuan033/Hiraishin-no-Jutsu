using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 lastMove;
    [SerializeField] private float speed;
    [SerializeField] private float kunaiSpeed;
    private Animator anim;

    public GameObject crosshair;
    public float crosshairDistance = 1.0f;
    public bool endOfAiming;
    public GameObject kunaiPrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Animation
        Animate();

        //Jump

        //Aim
        Aim();

        //shoot
        Kunai();
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
        if (movementInput != Vector2.zero)
        {
            lastMove = movementInput;
        }

        endOfAiming = Input.GetMouseButtonDown(0);
    }

    void Animate()
    {
        anim.SetFloat("XInput", movementInput.x);
        anim.SetFloat("YInput", movementInput.y);
        anim.SetBool("Walking", movementInput.magnitude > 0);

        if (movementInput == Vector2.zero)
        {
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
    }

    void Aim()
    {
        if (movementInput != Vector2.zero)
        {
            crosshair.transform.localPosition = movementInput * crosshairDistance;
        }

    }

    void Kunai()
    {
        Vector2 kunaiDirection = crosshair.transform.localPosition;
        kunaiDirection.Normalize();

        if (endOfAiming)
        {
            GameObject kunai = Instantiate(kunaiPrefab, transform.position, Quaternion.identity);
            kunai.GetComponent<Rigidbody2D>().velocity = kunaiDirection * kunaiSpeed;
            kunai.transform.Rotate(0, 0, Mathf.Atan2(kunaiDirection.y, kunaiDirection.x)* Mathf.Rad2Deg);
            Destroy(kunai, 2.0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 lastMove;
    [SerializeField] private float speed;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Animation
        Animate();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
        if (movementInput != Vector2.zero)
        {
            lastMove = movementInput;
        }
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
}

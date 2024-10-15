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
            lastMove= movementInput;
            Animate();
        }
        else
        {
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
    }

    void Animate()
    {
        anim.SetFloat("XInput", movementInput.x);
        anim.SetFloat("YInput", movementInput.y);
        anim.SetFloat("Moving", movementInput.magnitude);
    }
}

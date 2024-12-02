using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private int speed;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {

            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        //varient 1
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        //variant 2
        /*if (movement.x != 0 || movement.y != 0)
        {
            rb.linearVelocity = movement * speed;
        }*/
        //varient 3
        rb.AddForce(movement * speed);
    }

}

using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movment : MonoBehaviour
{
    public int FacingDirection = 1;
    public Rigidbody2D rb;
    public Animator animator;
    public bool enabled_move;

    void FixedUpdate()
    {
        if (!enabled_move) return
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        animator.SetFloat("horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("vertical", Mathf.Abs(vertical));
        rb.linearVelocity = new Vector2(horizontal, vertical) * Stats_Manager.Instance.Speed;
    }

    void Flip()
    {
        FacingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    /*
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    public bool enabled_move;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnMovement(InputValue value)
    {
        if (enabled_move)
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
    //varient 3*/
    /*rb.AddForce(movement * Stats_Manager.Instance.Speed);
}*/

}

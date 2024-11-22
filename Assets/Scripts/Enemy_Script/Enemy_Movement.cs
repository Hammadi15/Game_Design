using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.XR;

public class Enemy_Movement : MonoBehaviour
{
    //Make it posible to change the speed of witch the enemy moves
    public float Speed;
    // set the fasing direction
    private int FacingDirection = -1;
    //Keeps trak of current state(animation)
    private EnemyState enemyState;

    //Defines the Rigidbody2D is being used
    private Rigidbody2D rb;

    //Defines the Transform object is being used
    private Transform player;

    //Defines the Animator is being used
    private Animator animate;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting components from the called components and adding them in to there respective calls
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();

        //Changes animation stat to Idle in the begining
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {   //Checking witch state the enemy is in
        if (enemyState == EnemyState.Moving)
        {
            //Tracs the players x position and if it is greater then the x position of the assined object, flip the ojects x scale to the outer direction
            if (player.position.x > transform.position.x && FacingDirection == -1 ||
            player.position.x < transform.position.x && FacingDirection == 1)
            {
                Flip();
            }
            //Sets what it is the track and the spped of which it moves 
            Vector2 Direction = (player.position - transform.position).normalized;
            rb.linearVelocity = Direction * Speed;
        }
    }

    //Creating the Flip funtion
    void Flip()
    {

        FacingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


    //If the player is inside of the aggro range this code is run
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if the gameObject that entered the Aggro range has the tag of Player
        if (collision.gameObject.tag == "Player")
        {
            //If The Transformer has not bin assined yet, then assign it to the gameObject with tag Player
            if (player == null)
            {
                player = collision.transform;
            }
            //changing animation state to moving
            ChangeState(EnemyState.Moving);
        }
    }
    //If the player is no longer inside of the aggro range this code is run
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Checking if the gameObject that left the Aggro range has the tag of Player
        if (collision.gameObject.tag == "Player")
        {
            //sets the speed of the Assiged body to zero.
            rb.linearVelocity = Vector2.zero;
            //changing animation state to Idle
            ChangeState(EnemyState.Idle);
        }
    }

    void ChangeState(EnemyState NewState)
    {
        //Exiting the current animation
        if (enemyState == EnemyState.Idle)
        {
            animate.SetBool("IsIdle", false);
        }

        else if (enemyState == EnemyState.Moving)
        {
            animate.SetBool("IsMoving", false);
        }

        //Uppdates our current animation
        enemyState = NewState;

        //Uppdate our new animation
        if (enemyState == EnemyState.Idle)
        {
            animate.SetBool("IsIdle", true);
        }

        else if (enemyState == EnemyState.Moving)
        {
            animate.SetBool("IsMoving", true);
        }
    }
}

// creating states for my carecter
public enum EnemyState
{
    Idle,
    Moving,
    Attaking
}
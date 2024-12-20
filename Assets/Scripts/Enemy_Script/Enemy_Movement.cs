using UnityEngine;
using UnityEngine.AI;
public class Enemy_Movement : MonoBehaviour
{
    //Make it posible to change the speed of witch the enemy moves
    public float Speed;

    //sets a range of attack for the enemy
    public float AttackRange = 0.6f;

    //A cooldown time for attacking
    public float AttackCoolDown = 2;

    //A range for the enemy to detect the player
    public float playerDetectRange = 4;

    //decetionPoint for the enemy
    public Transform DetectionPoint;

    //A layermask to trak the asined gameobject
    public LayerMask playerLayer;

    //A uppdatebole timer for attacks
    private float AttackCoolDownTimer;
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
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting components from the called components and adding them in to there respective calls
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //Changes animation stat to Idle in the begining
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //checking for the player
        CheckForPlayer();

        //Checking if the AttackCoolDownTimer is biger then 0, if it is true the run the code inside
        if (AttackCoolDownTimer > 0)
        {
            //Sets time to be the original time minus the time that has gone in the game.
            AttackCoolDownTimer -= Time.deltaTime;
        }

        //Checking witch state the enemy is in, if it is moving then run the code inside
        if (enemyState == EnemyState.Moving)
        {
            //calling the moving funtion
            moving();
        }
        //if the gameObject is not moving then check if it is attaking, if it is run the code inside
        else if (enemyState == EnemyState.Attacking)
        {
            //This is where we do the attack... stuff

            //when we are attacking and have attacked set the velocetyu of the gameObject to zero
            agent.isStopped = true;
        }
    }

    //Creating the moving funtion
    void moving()
    {
        //Tracs the players x position and if it is greater then the x position of the assined object, flip the ojects x scale to the outer direction
        if (player.position.x > transform.position.x && FacingDirection == -1 ||
           player.position.x < transform.position.x && FacingDirection == 1)
        {
            Flip();
        }

        //Sets what it is the track and the spped of which it moves 
        agent.isStopped = false;
        agent.SetDestination(player.position + new Vector3(0.6f * -FacingDirection, 0, 0));
    }


    //Creating the Flip funtion
    void Flip()
    {
        //This code lets the gameObject change its general x axis to look twords the Player
        FacingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


    //If the player is inside of the aggro range this code is run
    private void CheckForPlayer()
    {
        //checks if the gameObject that entered the circle collider2D is the player
        Collider2D[] hits = Physics2D.OverlapCircleAll(DetectionPoint.position, playerDetectRange, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            //If the position of the player is closer or equal to the attack range and the AttackCoolDownTimer is zero then run the code inside
            if (Vector2.Distance(transform.position, player.transform.position) <= AttackRange && AttackCoolDownTimer <= 0)
            {
                //resets the AttackCoolDownTimer to be its original time
                AttackCoolDownTimer = AttackCoolDown;

                //change the state of animation to the Attacking animation of the gameObject
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, player.position) > AttackRange)
            {
                //change the state of animation to the Moving animation of the gameObject
                ChangeState(EnemyState.Moving);
            }
        }
        else
        {
            //sets the speed of the Assiged body to zero.
            agent.isStopped = true;
            //change the state of animation to the Idle animation of the gameObject
            ChangeState(EnemyState.Idle);
        }
    }
    //This code could be used but the code above is more streamlined
    /*  private void OnTriggerEnter2D(Collider2D collision)

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
}*/

    void ChangeState(EnemyState NewState)
    {
        //Exiting the current animation
        if (enemyState == EnemyState.Idle)
        {
            //Set bool in animator to false
            animate.SetBool("IsIdle", false);
        }

        else if (enemyState == EnemyState.Moving)
        {
            //Set bool in animator to false
            animate.SetBool("IsMoving", false);
        }

        else if (enemyState == EnemyState.Attacking)
        {
            //Set bool in animator to false
            animate.SetBool("IsAttacking", false);
        }

        //Uppdates our current animation
        enemyState = NewState;

        //Uppdate our new animation
        if (enemyState == EnemyState.Idle)
        {
            //Set bool in animator to true
            animate.SetBool("IsIdle", true);
        }

        else if (enemyState == EnemyState.Moving)
        {
            //Set bool in animator to true
            animate.SetBool("IsMoving", true);
        }

        else if (enemyState == EnemyState.Attacking)
        {
            //Set bool in animator to true
            animate.SetBool("IsAttacking", true);
        }

    }

    //This function draws up the visulizesion of the aggro range
    private void OnDrawGizmosSelected()
    {
        //sets the color to white
        Gizmos.color = Color.white;
        //Sets the position of where it is going to show on the position of DetectionPoint, and making the radius be the playerDetectRange
        Gizmos.DrawWireSphere(DetectionPoint.position, playerDetectRange);
    }
}

// creating states for character
public enum EnemyState
{
    Idle,
    Moving,
    Attacking
}
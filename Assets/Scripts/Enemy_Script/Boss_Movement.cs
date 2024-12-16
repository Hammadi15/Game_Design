using UnityEngine;

public class Boss_Movement : MonoBehaviour
{
    //Make it posible to change the speed of witch the enemy moves
    public float Speed;

    //sets a range of attack for the enemy
    public float AttackRange = 0.6f;
    public float TeleportCoolDown = 3f; // New teleport cooldown

    //A cooldown time for attacking
    public float AttackCoolDown = 2;

    //A range for the enemy to detect the player
    public float playerDetectRange = 4;

    //decetionPoint for the enemy
    public Transform DetectionPoint;
    private float TeleportCoolDownTimer; // Timer for teleport cooldown

    //A layermask to trak the asined gameobject
    public LayerMask playerLayer;

    //A uppdatebole timer for attacks
    private float AttackCoolDownTimer;
    // set the fasing direction
    private int FacingDirection = -1;
    //Keeps trak of current state(animation)
    private BossnemyState BossnemyState;

    //Defines the Rigidbody2D is being used
    private Rigidbody2D rb;

    //Defines the Transform object is being used
    public Transform player;

    //Defines the Animator is being used
    private Animator animate;

    [SerializeField] private float JumpAttackRange;
        [SerializeField] private float PlayerZone;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting components from the called components and adding them in to there respective calls
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();

        //Changes animation stat to Idle in the begining
        ChangeState(BossnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        //checking for the player
        CheckForPlayer();

        //Checking if the AttackCoolDownTimer is biger then 0, if it is true the run the code inside
        if (AttackCoolDownTimer > 0)
        {
            //Sets time to be the original time minus the time that has gone in the game.
            AttackCoolDownTimer -= Time.deltaTime;
        }

        // Handle teleport cooldown
        if (TeleportCoolDownTimer > 0)
        {
            TeleportCoolDownTimer -= Time.deltaTime;
        }

        //Checking witch state the enemy is in, if it is moving then run the code inside
        if (BossnemyState == BossnemyState.Moving)
        {
            //calling the moving funtion
            moving();
        }
        //if the gameObject is not moving then check if it is attaking, if it is run the code inside
        else if (BossnemyState == BossnemyState.Attacking)
        {
            //This is where we do the attack... stuff

            //when we are attacking and have attacked set the velocetyu of the gameObject to zero
            rb.linearVelocity = Vector2.zero;
        }

        else if (BossnemyState == BossnemyState.Teleporting) // Changed to BossnemyState
        {
            // Handle teleporting state
        }
    }

    //Creating the moving funtion
    void moving()
    {
        new Vector2(player.position.x, player.position.y);
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
        if (Vector2.Distance(DetectionPoint.position, player.position) <= playerDetectRange)
        {
            // Teleport logic when player is in range
            if (TeleportCoolDownTimer <= 0 && Vector2.Distance(transform.position, player.position) > AttackRange)
            {
                TeleportToPlayer();
                TeleportCoolDownTimer = TeleportCoolDown; // Start cooldown after teleport
                ChangeState(BossnemyState.Teleporting); // Changed to BossnemyState
            }
            // Attack logic
            else if (Vector2.Distance(transform.position, player.transform.position) <= AttackRange && AttackCoolDownTimer <= 0)
            {
                AttackCoolDownTimer = AttackCoolDown;
                ChangeState(BossnemyState.Attacking); // Changed to BossnemyState
            }
            // Move toward player if they are not in attack range
            else if (Vector2.Distance(transform.position, player.position) > AttackRange)
            {
                ChangeState(BossnemyState.Moving); // Changed to BossnemyState
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(BossnemyState.Idle); // Changed to BossnemyState
        }
    }



    void ChangeState(BossnemyState NewState)
    {
        //Exiting the current animation
        if (BossnemyState == BossnemyState.Idle)
        {
            //Set bool in animator to false
            animate.SetBool("IsIdle", false);
        }

        else if (BossnemyState == BossnemyState.Moving)
        {
            //Set bool in animator to false
            animate.SetBool("IsMoving", false);
        }

        else if (BossnemyState == BossnemyState.Attacking)
        {
            //Set bool in animator to false
            animate.SetBool("IsAttacking", false);
        }

        //Uppdates our current animation
        BossnemyState = NewState;

        //Uppdate our new animation
        if (BossnemyState == BossnemyState.Idle)
        {
            //Set bool in animator to true
            animate.SetBool("IsIdle", true);
        }

        else if (BossnemyState == BossnemyState.Moving)
        {
            //Set bool in animator to true
            animate.SetBool("IsMoving", true);
        }

        else if (BossnemyState == BossnemyState.Attacking)
        {
            //Set bool in animator to true
            animate.SetBool("IsAttacking", true);
        }

    }

    void TeleportToPlayer()
    {
        // Set the desired offset distance from the player.
        float teleportDistance = 2.5f; // Adjust this to the desired teleport distance.

        // Calculate the direction vector from the boss to the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Calculate the new position by applying the offset distance
        Vector3 teleportPosition = player.position - directionToPlayer * teleportDistance;

        // Apply the teleportation
        transform.position = new Vector3(teleportPosition.x, teleportPosition.y, transform.position.z);
    }

    //This function draws up the visulizesion of the aggro range
    private void OnDrawGizmosSelected()
    {
        //sets the color to white
        Gizmos.color = Color.white;
        //Sets the position of where it is going to show on the position of DetectionPoint, and making the radius be the playerDetectRange
        Gizmos.DrawWireSphere(DetectionPoint.position, playerDetectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, PlayerZone);

    }




}

// creating states for character

public enum BossnemyState // Kept as BossnemyState
{
    Idle,
    Moving,
    Attacking,
    Teleporting
}
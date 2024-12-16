using UnityEngine;

public class Boss_Combat : MonoBehaviour
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
    private BossState bossState;

    //Defines the Rigidbody2D is being used
    private Rigidbody2D rb;

    //Defines the Transform object is being used
    public Transform player;

    //Defines the Animator is being used
    private Animator animate;

    [SerializeField] private float JumpAttackRange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting components from the called components and adding them in to there respective calls
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();

        //Changes animation stat to Idle in the begining
        ChangeState(BossState.Idle);
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

        //Checking witch state the enemy is in, if it is moving then run the code inside
        if (bossState == BossState.Moving)
        {
            //calling the moving funtion
            moving();
        }
        //if the gameObject is not moving then check if it is attaking, if it is run the code inside
        else if (bossState == BossState.Attacking)
        {
            //This is where we do the attack... stuff

            //when we are attacking and have attacked set the velocetyu of the gameObject to zero
            rb.linearVelocity = Vector2.zero;
        }
    }

    //Creating the moving funtion
    void moving()
    {
        //new Vector2(player.position.x, player.position.y);
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
        //checks if the gameObject that entered the circle collider2D is the player
        if (Vector2.Distance(DetectionPoint.position, player.position) <= playerDetectRange)
        {

            //If the position of the player is closer or equal to the attack range and the AttackCoolDownTimer is zero then run the code inside
            if (Vector2.Distance(transform.position, player.transform.position) <= AttackRange && AttackCoolDownTimer <= 0)
            {
                //resets the AttackCoolDownTimer to be its original time
                AttackCoolDownTimer = AttackCoolDown;

                //change the state of animation to the Attacking animation of the gameObject
                ChangeState(BossState.Attacking);
            }
            else if (Vector2.Distance(transform.position, player.position) > AttackRange)
            {
                //change the state of animation to the Moving animation of the gameObject
                ChangeState(BossState.Moving);
            }
        }
        else
        {
            //sets the speed of the Assiged body to zero.
            rb.linearVelocity = Vector2.zero;
            //change the state of animation to the Idle animation of the gameObject
            ChangeState(BossState.Idle);
        }
    }


    void ChangeState(BossState NewState)
    {
        //Exiting the current animation
        if (bossState == BossState.Idle)
        {
            //Set bool in animator to false
            animate.SetBool("IsIdle", false);
        }

        else if (bossState == BossState.Moving)
        {
            //Set bool in animator to false
            animate.SetBool("IsMoving", false);
        }

        else if (bossState == BossState.Attacking)
        {
            //Set bool in animator to false
            animate.SetBool("IsAttacking", false);
        }

        //Uppdates our current animation
        bossState = NewState;

        //Uppdate our new animation
        if (bossState == BossState.Idle)
        {
            //Set bool in animator to true
            animate.SetBool("IsIdle", true);
        }

        else if (bossState == BossState.Moving)
        {
            //Set bool in animator to true
            animate.SetBool("IsMoving", true);
        }

        else if (bossState == BossState.Attacking)
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

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, JumpAttackRange);

    }
    private void Awake()
    {
        player = Doormgr.Instance.player.transform;
    }



}

// creating states for character

public enum BossState
{
    Idle,
    Moving,
    Attacking,
    jumping
}
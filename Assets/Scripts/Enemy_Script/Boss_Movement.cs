using UnityEngine;

public class Boss_Movement : MonoBehaviour
{
    public float Speed;
    public float AttackRange = 0.6f;
    public float AttackCoolDown = 2;
    public float TeleportCoolDown = 3f; // New teleport cooldown
    public float playerDetectRange = 4;
    public Transform DetectionPoint;
    public LayerMask playerLayer;
    private float AttackCoolDownTimer;
    private float TeleportCoolDownTimer; // Timer for teleport cooldown
    private int FacingDirection = -1;
    private BossnemyState bossState; // Changed to BossnemyState
    private Rigidbody2D rb;
    public Transform player;
    private Animator animate;

    [SerializeField] private float PlayerZone;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        ChangeState(BossnemyState.Idle); // Changed to BossnemyState
    }

    void Update()
    {
        CheckForPlayer();

        if (AttackCoolDownTimer > 0)
        {
            AttackCoolDownTimer -= Time.deltaTime;
        }

        // Handle teleport cooldown
        if (TeleportCoolDownTimer > 0)
        {
            TeleportCoolDownTimer -= Time.deltaTime;
        }

        if (bossState == BossnemyState.Moving) // Changed to BossnemyState
        {
            moving();
        }
        else if (bossState == BossnemyState.Attacking) // Changed to BossnemyState
        {
            rb.linearVelocity = Vector2.zero;
        }
        else if (bossState == BossnemyState.Teleporting) // Changed to BossnemyState
        {
            // Handle teleporting state
        }
    }

    void moving()
    {
        if (player.position.x > transform.position.x && FacingDirection == -1 || player.position.x < transform.position.x && FacingDirection == 1)
        {
            Flip();
        }

        Vector2 Direction = (player.position - transform.position).normalized;
        rb.linearVelocity = Direction * Speed;
    }

    void Flip()
    {
        FacingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

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

    void ChangeState(BossnemyState NewState) // Changed to BossnemyState
    {
        if (bossState == BossnemyState.Idle) animate.SetBool("IsIdle", false);
        else if (bossState == BossnemyState.Moving) animate.SetBool("IsMoving", false);
        else if (bossState == BossnemyState.Attacking) animate.SetBool("IsAttacking", false);

        bossState = NewState;

        if (bossState == BossnemyState.Idle) animate.SetBool("IsIdle", true);
        else if (bossState == BossnemyState.Moving) animate.SetBool("IsMoving", true);
        else if (bossState == BossnemyState.Attacking) animate.SetBool("IsAttacking", true);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(DetectionPoint.position, playerDetectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, PlayerZone);
    }
}

public enum BossnemyState // Kept as BossnemyState
{
    Idle,
    Moving,
    Attacking,
    Teleporting
}

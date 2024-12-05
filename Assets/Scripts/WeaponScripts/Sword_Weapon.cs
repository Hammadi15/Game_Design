using UnityEngine;

public class Sword_Weapon : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator myAnimator;

    [SerializeField] private float shootCooldown = 0.5f; // Cooldown duration in seconds
    private bool isFiring = false; // Tracks if the player is holding the fire button
    private bool canAttack = true; // Tracks if the weapon can attack (cooldown complete)
    [SerializeField] private AudioClip swordSound;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => StartFiring();
        playerControls.Combat.Attack.canceled += _ => StopFiring();
    }

    private void StartFiring()
    {
        isFiring = true;
        if (canAttack)
        {
            StartCoroutine(AttackWithCooldown());    
        }
            
    }

    private void StopFiring()
    {
        isFiring = false;
    }

    private System.Collections.IEnumerator AttackWithCooldown()
    {
        while (isFiring && canAttack)
        {
            canAttack = false; // Prevent immediate re-attack
            myAnimator.SetTrigger("Attack");
            SoundManager.instance.PlaySound(swordSound);
            yield return new WaitForSeconds(shootCooldown); // Wait for cooldown
            canAttack = true;
        }
    }
}

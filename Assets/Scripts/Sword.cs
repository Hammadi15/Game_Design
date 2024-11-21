using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimationPrefab;
    [SerializeField] private Transform slashAnimationPoint;

    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerMovment playerMovment;
    private ActiveWepon activeWepon;

    private GameObject slashAnimation;

    private void Awake()
    {
        playerMovment = GetComponentInParent<PlayerMovment>();
        activeWepon = GetComponentInParent<ActiveWepon>();

        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Combat.Attack.started += OnAttackStarted;
    }

    private void OnDisable()
    {
        playerControls.Combat.Attack.started -= OnAttackStarted;
        playerControls.Disable();
    }

    private void OnAttackStarted(InputAction.CallbackContext context)
    {
        Attack();
    }

    private void Attack()
    {
        if (myAnimator != null)
        {
            myAnimator.SetTrigger("Attack");
        }
        else
        {
            Debug.LogWarning("Animator not set on Sword.");
        }

        if (slashAnimationPrefab != null && slashAnimationPoint != null)
        {
            slashAnimation = Instantiate(slashAnimationPrefab, slashAnimationPoint.position, Quaternion.identity);
            slashAnimation.transform.parent = this.transform.parent;
        }
        else
        {
            Debug.LogWarning("Slash Animation Prefab or Slash Animation Point not set.");
        }
    }
}

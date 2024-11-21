using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator myAnimator;


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Attack()
    {
        myAnimator.SetTrigger("Attack");
        throw new NotImplementedException();
    }
}

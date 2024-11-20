using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    private PlayerMovment playerControls;
    private Animator myAnimator;


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerMovment();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
}

using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    private static ActiveWeapon instance;

    public static ActiveWeapon Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Object.FindFirstObjectByType<ActiveWeapon>();
            }
            return instance;
        }
    }

    [SerializeField] private MonoBehaviour currentActiveWeapon;
    private Pointer pointer;
    private bool attackButtonDown, isAttacking = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Ensures only one instance exists
        }

        pointer = new Pointer();
    }

    private void OnEnable()
    {
        pointer.Enable();
    }

    private void Start()
    {
        pointer.PlayerPointer.Attack.started += _ => StartAttacking();
        pointer.PlayerPointer.Attack.canceled += _ => StopAttacking();
    }

    private void Update()
    {
        Attack();
    }

    public void ToggleIsAttacking(bool value)
    {
        isAttacking = value;
    }

    private void StartAttacking()
    {
        attackButtonDown = true;
    }

    private void StopAttacking()
    {
        attackButtonDown = false;
    }

    private void Attack()
    {
        if (attackButtonDown && !isAttacking)
        {
            isAttacking = true;
            (currentActiveWeapon as IWeapon).Attack();
        }
    }
}

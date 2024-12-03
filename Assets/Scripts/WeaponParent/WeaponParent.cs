using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponParent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector2 pointrInput;
    public Vector2 PointerInput => pointrInput;

    private WeaponParent weaponParent;

    [SerializeField] private InputActionReference attack,pointerPositon;
    public Vector2 PointerPosition { get; set; }

   /* private void Update()
    {
        pointrInput = GetPointerInput();
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;

    }
    private Vector2 GetPointerInput()
    {

    }
    */
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimAndShoot : MonoBehaviour
{

    [SerializeField] private GameObject gun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created 

    private Vector2 worldPosition;
    private Vector2 direction;
    private void Update()
    {
        HandleGundRotation();
    }
    private void HandleGundRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2) gun.transform.position).normalized;
        gun.transform.right = direction;

    }
}

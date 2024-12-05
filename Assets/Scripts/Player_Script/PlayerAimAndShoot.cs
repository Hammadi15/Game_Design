using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpwanPoint;
    [SerializeField] private float shootCooldown = 0.5f; // Cooldown duration in seconds
    private bool isFiring = false; // Tracks if the player is holding the fire button

    private float timer = 0f; // Tracks cooldown time
    private bool isActive = true; // Tracks if the bow is currently active

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    private void Update()
    {
        if (!isActive) return; // Skip if the bow is unequipped

        HandleGunRotation();
        HandleGunShooting();
        UpdateCooldownTimer();
    }

    private void HandleGunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 localScale = new Vector3(1f, 1f, 1f);
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        gun.transform.localScale = localScale;
    }

    private void HandleGunShooting()
    {
        // Check if the fire button is held down
        if (Mouse.current.leftButton.isPressed && timer <= 0f)
        {
            // Spawn bullet
            Instantiate(bullet, bulletSpwanPoint.position, gun.transform.rotation);
            timer = shootCooldown;
        }
    }

    private void UpdateCooldownTimer()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
    }

    // Method to enable or disable the bow
    public void SetActive(bool active)
    {
        isActive = active;
        gun.SetActive(active); // Optionally, hide the gun when not in use
    }
}

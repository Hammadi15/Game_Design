
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    public GameObject Bullet;
    [SerializeField] private Transform bulletSpwanPoint;
    [SerializeField] private float shootCooldown = 0.5f; // Cooldown duration in seconds
    [SerializeField] private AudioClip shootSound;

    public int BulletCount = 10;
    private float timer = 0f; // Tracks cooldown time
    public bool isActive = false; // Tracks if the bow is currently active

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    private void Update()
    {
        if (!isActive) return; // Skip if the bow is unequipped

        HandleGunRotation();
        HandleGunShooting();
        UpdateCooldownTimer();
        BulletCount = math.min(BulletCount, 10);
    }

    private void HandleGunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 localScale = new Vector3(1f, 1f, 1f);
        float player_flipped = this.transform.parent.transform.parent.transform.localScale.x;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        gun.transform.localScale = localScale * player_flipped;
    }

    private void HandleGunShooting()
    {

        // Check if the fire button is held down
        if (Mouse.current.leftButton.isPressed && timer <= 0f && BulletCount > 0)
        {
            BulletCount--;
            // Spawn bullet
            Instantiate(Bullet, bulletSpwanPoint.position, gun.transform.rotation);
            timer = shootCooldown;
            SoundManager.instance.PlaySound(shootSound);
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

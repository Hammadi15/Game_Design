using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerAimAndShoot : MonoBehaviour
{

    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpwanPoint;

    private GameObject bulletInst;

    // Start is called once before the first execution of Update after the MonoBehaviour is created 

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    private void Update()
    {
        HandleGundRotation();
        HnadleGunShooting();
    }
    private void HandleGundRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2) gun.transform.position).normalized;
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

    private void HnadleGunShooting()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Spwan bullet
            bulletInst =  Instantiate(bullet, bulletSpwanPoint.position, gun.transform.rotation);
        }
    }


}

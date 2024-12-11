using UnityEngine;

public class Bullet_Count : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponentInChildren<PlayerAimAndShoot>().BulletCount = 0;

    }
}


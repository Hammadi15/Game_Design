using UnityEditor.Rendering;
using UnityEngine;

public class Bullet_Count : MonoBehaviour
{
    public bool ShouldNotDissaper = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<PlayerAimAndShoot>().BulletCount += 5;
            if (!ShouldNotDissaper)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}


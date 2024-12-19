using System;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Header("General Bullet Stats")]
    [SerializeField] private LayerMask whatDestroysBullet;
    [SerializeField] private float destoryTime = 3f; //Destoy time 

    [Header("Normal Bullet Stats")]
    [SerializeField] private float normalBulletSpeed = 15f; //bullet speed

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //change rb stats based on bullet stats
        SetDestoryTimer(); //putting Destoy function after 3s deletes part
        InitializeBulletStats(); //putting function


    }

    public void InitializeBulletStats()
    {
        SetStraightVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the collision within the whatDestroysBullet layermask
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            //where we will add Damage Enemy
            Enemy_Health iDamage = collision.gameObject.GetComponent<Enemy_Health>();
            if (iDamage != null)
            {
                iDamage.ChangeHealth(Stats_Manager.Instance.Bow_Damage);

            }
            Boss_Health vDamage = collision.gameObject.GetComponent<Boss_Health>();
            if (vDamage != null)
            {
                vDamage.ChangeHealth(Stats_Manager.Instance.Bow_Damage);

            }
            Destroy(gameObject);
        }
    }

    private void SetStraightVelocity() //created function for speed
    {
        rb.linearVelocity = transform.right * normalBulletSpeed; //speed which takes veclocity which is 15 and times it on right side
    }
    private void SetDestoryTimer() // function
    {
        Destroy(gameObject, destoryTime);
    }
}

using System;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Header("General Bullet Stats")]
    [SerializeField] private LayerMask whatDestroysBullet;
    [SerializeField] private float destoryTime = 3f; //Destoy time 

    [Header ("Normal Bullet Stats")]
    [SerializeField] private float normalBulletSpeed = 15f; //bullet speed
    [SerializeField] private int normalBulletDamage = 1;

    [Header("Physics Bullet stats")]
    [SerializeField] private float physicsBulletSpeed = 17.5f;
    [SerializeField] private float physicsBulletGravity = 3f;
    [SerializeField] private int physicsBulletDamage = 2;

    private Rigidbody2D rb;
    private int damage;
    public enum BulletType
    {
        Normal,
        Physics
    }

    public BulletType bulletType;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //change rb stats based on bullet stats
        SetDestoryTimer(); //putting Destoy function after 3s deletes part
        InitializeBulletStats(); //putting function


    }

    private void FixedUpdate()
    {
        if (bulletType == BulletType.Physics)
        {
            //rotate bullet in direction of velocity
            transform.right = rb.linearVelocity;
        }
    }
    public void InitializeBulletStats()
    {
        if (bulletType == BulletType.Normal)
        {
            SetStraightVelocity();
            damage = normalBulletDamage;
        }
        else if (bulletType == BulletType.Physics)
        {
            SetPhysicsVelocity();
            damage = physicsBulletDamage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the collision within the whatDestroysBullet layermask
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) >0)
            {
            //where we will add Damage Enemy
            Enemy_Health iDamage = collision.gameObject.GetComponent<Enemy_Health>();
            if (iDamage != null)
            {
                iDamage.ChangeHealth(damage);

            }
            Destroy(gameObject);
        }
    }

    private void SetPhysicsVelocity()
    {
        rb.linearVelocity = transform.right * physicsBulletSpeed;
    }
    private void SetStraightVelocity() //created function for speed
    {
        rb.linearVelocity = transform.right * physicsBulletSpeed; //speed which takes veclocity which is 15 and times it on right side
    }
    private void SetDestoryTimer() // function
    {
        Destroy(gameObject, destoryTime);
    }

    private void SetRBStats()
    {
        if (bulletType == BulletType.Normal)
        {
            rb.gravityScale = 0f;
        }
        else if (bulletType == BulletType.Physics)
        {
            rb.gravityScale = physicsBulletGravity;
        }
    }
}

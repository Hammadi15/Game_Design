using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    [SerializeField] private float normalBulletSpeed = 15f; //bullet speed
    [SerializeField] private float destoryTime = 3f; //Destoy time 
    [SerializeField] private LayerMask whatDestroysBullet;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
      SetStraightVelocity(); //putting function
        SetDestoryTimer(); //putting Destoy function after 3s deletes part
  }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the collision within the whatDestroysBullet layermask
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) >0)
            {
            //where we will add Damage Enemy
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

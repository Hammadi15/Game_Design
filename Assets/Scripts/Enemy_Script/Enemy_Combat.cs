using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{

    //creates a variable that can be changed manuly for every Enemy
    public int Damage = 1;
    public Transform AttackPoint;
    public float WeaponRange;
    public LayerMask playerLayer;

    private void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Health>().ChangeHealth(Damage);
        }
    }

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPoint.position, WeaponRange, playerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<Player_Health>().ChangeHealth(Damage); ;
        }
    }
    //This function draws up the visulizesion of the aggro range
    private void OnDrawGizmosSelected()
    {
        //sets the color to white
        Gizmos.color = Color.green;
        //Sets the position of where it is going to show on the position of DetectionPoint, and making the radius be the playerDetectRange
        Gizmos.DrawWireSphere(AttackPoint.position, WeaponRange);

    }
}



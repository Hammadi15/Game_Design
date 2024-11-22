using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{

    //creates a variable that can be changed manuly for every Enemy
    public int Damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Health>().ChangeHealth(Damage);
        }
    }
}

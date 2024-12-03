using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy_Health>().ChangeHealth(Stats_Manager.Instance.Damage);
        }
    }
}

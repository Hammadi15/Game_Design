using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy_Health>().ChangeHealth(Stats_Manager.Instance.Sword_Damage);
            SoundManager.instance.PlaySound(hitSound);
        }
    }
}

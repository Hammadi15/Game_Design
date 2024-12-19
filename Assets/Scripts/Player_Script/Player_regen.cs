using UnityEngine;

public class Player_regen : MonoBehaviour
{

    public bool ShouldNotDissaper = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Stats_Manager.Instance.CurrentHealth < 5)
        {
            collision.gameObject.GetComponentInChildren<Player_Health>().ChangeHealth(-1);
            {
                this.gameObject.SetActive(false);
            }
        }

    }
}

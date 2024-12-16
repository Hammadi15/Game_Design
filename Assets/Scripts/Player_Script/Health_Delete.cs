using UnityEngine;

public class Health_Delete : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
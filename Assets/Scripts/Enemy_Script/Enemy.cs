using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    [SerializeField] private float maxHealth = 5f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float damageAdmount)
    {
        currentHealth -= damageAdmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

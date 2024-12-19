using TMPro;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{


    public int CurrentHealth;
    public int MaxHealth;
    public Boss_Helath_UI Health_Bar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        CurrentHealth = MaxHealth;

        Health_Bar.Boss_Max_Health(MaxHealth);
    }

    public void ChangeHealth(int amount)
    {
        CurrentHealth -= amount;

        Health_Bar.Boss_Health(CurrentHealth);

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        else if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Enemy_manager.Instance.enemy_count -= 1;
            Stats_Manager.Instance.Timestop = true;
        }
    }

}

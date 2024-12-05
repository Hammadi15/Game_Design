using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int ExperienceReward = 3;

    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;

    [SerializeField] private AudioClip deathSound;

    public int CurrentHealth;
    public int MaxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void ChangeHealth(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        else if (CurrentHealth <= 0)
        {
            OnMonsterDefeated(ExperienceReward);
            Destroy(gameObject);
            SoundManager.instance.PlaySound(deathSound);

        }
    }
}

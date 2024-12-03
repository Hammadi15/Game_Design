using UnityEngine;

public class Stats_Manager : MonoBehaviour
{

    public static Stats_Manager Instance;
    [Header("Combat Stats")]
    public int Damage;
    public int WeaponRange;
    public float StunTime;

    [Header("Speed stats")]
    public int Speed;

    [Header("Health stats")]
    public int MaxHealth = 5;
    public int CurrentHealth = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

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
    public GameObject restart_ui;

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
    private void Update()
    {
        if (CurrentHealth <= 0 && !restart_ui.activeSelf)
        {
            restart_ui.SetActive(true);
        }
    }
}

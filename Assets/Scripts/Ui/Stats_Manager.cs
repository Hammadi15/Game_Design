using UnityEngine;

public class Stats_Manager : MonoBehaviour
{

    public static Stats_Manager Instance;
    [Header("Combat Stats")]
    private int start_Sword_Damage;
    public int Sword_Damage;

    private int start_Bow_Damage;
    public int Bow_Damage;

    private float start_StunTime;
    public float StunTime;

    [Header("Speed stats")]
    private int start_Speed;
    public int Speed;

    [Header("Health stats")]
    public int MaxHealth = 5;
    public int CurrentHealth;
    public GameObject restart_ui;
    public bool done_tutorial;

    private void Awake()
    {
        start_Speed = Speed;
        start_StunTime = StunTime;
        start_Sword_Damage = Sword_Damage;
        start_Bow_Damage = Bow_Damage;
        CurrentHealth = MaxHealth;
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
    public void Restart()
    {
        Speed = start_Speed;
        StunTime = start_StunTime;
        Sword_Damage = start_Sword_Damage;
        Bow_Damage = start_Bow_Damage;
        CurrentHealth = MaxHealth;
    }
}

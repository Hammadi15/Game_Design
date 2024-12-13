using TMPro;
using UnityEngine;

public class Enemy_Count_UI : MonoBehaviour
{
    public TMP_Text EnemyDisplay_Text;


    public int Count;
    public static Enemy_Count_UI Instance;

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

    void Update()
    {
        if (Enemy_manager.Instance)
        {
            Count = Enemy_manager.Instance.enemy_count;
        }
        else
        {
            Count = 0;
        }
        EnemyDisplay_Text.text = "Enemys: " + Count;
    }
}

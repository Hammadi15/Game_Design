using TMPro;
using UnityEngine;

public class Arrow_Cout_UI : MonoBehaviour
{
    public TMP_Text ArrowDisplay_Text;

    public PlayerAimAndShoot AimAndShoot;

    public int Count;
    public static Arrow_Cout_UI Instance;

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
        Count = AimAndShoot.BulletCount;
        ArrowDisplay_Text.text = "Arrow: " + Count;
    }
}

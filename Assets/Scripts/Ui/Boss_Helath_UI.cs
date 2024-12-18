using UnityEngine;
using UnityEngine.UI;
public class Boss_Helath_UI : MonoBehaviour
{

    public Slider Health_Bar;

    public void Boss_Max_Health(int health)
    {
        Health_Bar.maxValue = health;
        Health_Bar.value = health;
    }

    public void Boss_Health(int health)
    {
        Health_Bar.value = health;
    }
}

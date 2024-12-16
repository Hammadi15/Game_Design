using TMPro;
using UnityEngine;

public class Stats_UI : MonoBehaviour
{
    public GameObject[] Stats_Slots;
    public CanvasGroup Player_Stats_UI;

    //Bool used to be able to open the Player_Stats_UI panel
    private bool StatsOpen = false;

    public void Start()
    {
        UpdateAllStats();
    }

    private void Update()
    {
        if (!Stats_Manager.Instance.done_tutorial) return;
        UpdateAllStats();
        //Checking if the custom button called ToggleStats is pressed
        if (Input.GetButtonDown("ToggleStats"))
        {
            //If StatsOpen is ture set the Player_Stats_UI to active
            if (StatsOpen)
            {
                //This starts the game time and all object that rely on it
                Time.timeScale = 1;
                //this is a bool for closing the Player_Stats_UI
                Player_Stats_UI.alpha = 0;
                StatsOpen = false;
            }
            //else set Player_Stats_UI to of
            else
            {
                //This stops the game time and all object that rely on it
                Time.timeScale = 0;

                //this is a bool for opening the Player_Stats_UI
                Player_Stats_UI.alpha = 1;
                StatsOpen = true;
            }
        }
    }
    //Creates a funtion that sets the specific number of a stat from Stats_Manager and shows it in the designated spot, example Stats_Slots[0].
    public void UpdateSwordDamage()
    {
        //GetComponentInChildren targets the child of the gameObject that this script is on
        Stats_Slots[0].GetComponentInChildren<TMP_Text>().text = "Sword Damage: " + Stats_Manager.Instance.Sword_Damage;
    }
    public void UpdateBowDamage()
    {
        Stats_Slots[1].GetComponentInChildren<TMP_Text>().text = "Bow Damage: " + Stats_Manager.Instance.Bow_Damage;
    }
    public void UpdateStunTime()
    {
        Stats_Slots[2].GetComponentInChildren<TMP_Text>().text = "Stun: " + Stats_Manager.Instance.StunTime;
    }
    public void UpdateSpeed()
    {
        Stats_Slots[3].GetComponentInChildren<TMP_Text>().text = "Speed: " + Stats_Manager.Instance.Speed;
    }

    public void UpdateAllStats()
    {
        UpdateSwordDamage();
        UpdateBowDamage();
        UpdateStunTime();
        UpdateSpeed();
    }
}
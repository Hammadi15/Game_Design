using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Experience_Manager : MonoBehaviour
{
    public int Level;
    public int CurrentExp;
    public int ExpToLevel = 10;
    public float ExpGrowthMultiplier = 1.2f;
    public Slider Experience_Bar;
    public TMP_Text CurrentLevelText;
    public Stats_UI Player_Stats_UI;

    public void Start()
    {
        UpdateUI();
    }

    private void Update()
    {

        //This is just code that is used to try and see if the Experience gain funtions work
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GainExperiencePoints(2);
        }
        */
    }

    private void OnEnable()
    {
        Enemy_Health.OnMonsterDefeated += GainExperiencePoints;
    }
    private void OnDisable()
    {
        Enemy_Health.OnMonsterDefeated -= GainExperiencePoints;
    }

    public void GainExperiencePoints(int amount)
    {
        CurrentExp += amount;
        if (CurrentExp >= ExpToLevel)
        {
            LevelUp();
        }

        UpdateUI();
    }
    public void LevelUp()
    {
        Level++;
        CurrentExp -= ExpToLevel;
        ExpToLevel = Mathf.RoundToInt(ExpToLevel * ExpGrowthMultiplier);
        Stats_Manager.Instance.Damage += 1;
        Player_Stats_UI.UpdateDamage();

    }
    public void UpdateUI()
    {
        Experience_Bar.maxValue = ExpToLevel;
        Experience_Bar.value = CurrentExp;
        CurrentLevelText.text = "Level: " + Level;
    }
}

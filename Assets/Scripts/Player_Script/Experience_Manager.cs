using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Experience_Manager : MonoBehaviour
{
    public int Level;
    public int CurrentExp;
    public int ExpToLevel = 10;
    private int start_CurrentExp;
    private int start_ExpToLevel;
    public float ExpGrowthMultiplier = 1.2f;
    public Slider Experience_Bar;
    public TMP_Text CurrentLevelText;
    public Stats_UI Player_Stats_UI;
    public static Experience_Manager Instance;
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
    public void Start()
    {
        start_CurrentExp = CurrentExp;
        start_ExpToLevel = ExpToLevel;
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
    public void reset_all()
    {
        CurrentExp = start_CurrentExp;
        ExpToLevel = start_ExpToLevel;
        UpdateUI();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject bow;
    public GameObject inventory_UI;
    public GameObject Arrow_Enemy_Count_UI;
    public bool IDoNotGiveARatBullOfThisShit = false;
    public static StartMenu Instance;
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
    public void Start_but()
    {
        //disables the current GameObject
        gameObject.SetActive(false);
        //skips the dialog because it's long(theo made the name of the var)
        if (!IDoNotGiveARatBullOfThisShit)
        {
            Dialog.Instance.Start_trig();
        }
        else
        {
            end_trig();
        }
    }
    public void end_trig()
    {
        //resumes time to normal
        Time.timeScale = 1;
        //reEnables the bow 
        bow.GetComponent<PlayerAimAndShoot>().isActive = true;
        //enables movement of the player
        Player_Movment pm = player.GetComponent<Player_Movment>();
        pm.enabled_move = true;
        
        Stats_Manager.Instance.done_tutorial = true;
        //shows the inventory and enemy and arrow count
        CanvasGroup inventory_UI_CanvasGroup = inventory_UI.GetComponent<CanvasGroup>();
        inventory_UI_CanvasGroup.alpha = 1;
        inventory_UI_CanvasGroup.interactable = true;
        inventory_UI_CanvasGroup.blocksRaycasts = true;
        CanvasGroup Arrow_Enemy_Count_UI_CanvasGroup = Arrow_Enemy_Count_UI.GetComponent<CanvasGroup>();
        Arrow_Enemy_Count_UI_CanvasGroup.alpha = 1;
        Arrow_Enemy_Count_UI_CanvasGroup.interactable = true;
        Arrow_Enemy_Count_UI_CanvasGroup.blocksRaycasts = true;
    }
    public void Quit_but()
    {
        //closes the application but only works when you have built the unity project
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //disables the bow in the players inventory
        bow.GetComponent<PlayerAimAndShoot>().isActive = false;
        //freezes time
        Time.timeScale = 0;
        //fixes the player and camera so they work properly on start 
        Doormgr.Instance.Switched_area(SceneManager.GetActiveScene(), SceneManager.GetActiveScene());
    }

}

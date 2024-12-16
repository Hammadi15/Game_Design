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
        gameObject.SetActive(false);
        if (!IDoNotGiveARatBullOfThisShit)
        {
            Dialog.Instance.Start_trig(false);
        }
        else
        {
            end_trig();
        }
    }
    public void end_trig()
    {
        Time.timeScale = 1;
        bow.GetComponent<PlayerAimAndShoot>().isActive = true;
        Player_Movment pm = player.GetComponent<Player_Movment>();
        pm.enabled_move = true;
        CanvasGroup inventory_UI_CanvasGroup = inventory_UI.GetComponent<CanvasGroup>();
        inventory_UI_CanvasGroup.alpha = 1;
        inventory_UI_CanvasGroup.interactable = true;
        inventory_UI_CanvasGroup.blocksRaycasts = true;
        Stats_Manager.Instance.done_tutorial = true;
        CanvasGroup Arrow_Enemy_Count_UI_CanvasGroup = Arrow_Enemy_Count_UI.GetComponent<CanvasGroup>();
        Arrow_Enemy_Count_UI_CanvasGroup.alpha = 1;
        Arrow_Enemy_Count_UI_CanvasGroup.interactable = true;
        Arrow_Enemy_Count_UI_CanvasGroup.blocksRaycasts = true;
    }
    public void Quit_but()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bow.GetComponent<PlayerAimAndShoot>().isActive = false;
        Time.timeScale = 0;
        Doormgr.Instance.Switched_area(SceneManager.GetActiveScene(), SceneManager.GetActiveScene());
    }

}

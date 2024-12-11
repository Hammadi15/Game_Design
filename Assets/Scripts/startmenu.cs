using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject bow;
    public GameObject inventory_UI;
    public bool IDoNotGiveARatBullOfThisShit;
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
            Dialog.Instance.Start_trig();
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
        CanvasGroup temp_CanvasGroup = inventory_UI.GetComponent<CanvasGroup>();
        temp_CanvasGroup.alpha = 1;
        temp_CanvasGroup.interactable = true;
        temp_CanvasGroup.blocksRaycasts = true;
        Stats_Manager.Instance.done_tutorial = true;

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

    // Update is called once per frame
    void Update()
    {

    }
}

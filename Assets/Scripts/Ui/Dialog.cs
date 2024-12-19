using TMPro;
using UnityEngine;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;


public class Dialog : MonoBehaviour
{
    private static GameObject[] GetDontDestroyOnLoadObjects()
    {
        GameObject temp = null;
        try
        {
            temp = new GameObject();
            Object.DontDestroyOnLoad(temp);
            UnityEngine.SceneManagement.Scene dontDestroyOnLoad = temp.scene;
            Object.DestroyImmediate(temp);
            temp = null;

            return dontDestroyOnLoad.GetRootGameObjects();
        }
        finally
        {
            if (temp != null)
                Object.DestroyImmediate(temp);
        }
    }
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    public GameObject continueButton;
    public CanvasGroup Dialog_box_UI;

    private int index;
    public static Dialog Instance;
    private bool door_toggle;
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

    public void Start_trig(bool tog = false)
    {
        door_toggle = tog;
        Dialog_box_UI.alpha = 1;
        Dialog_box_UI.interactable = true;
        Dialog_box_UI.blocksRaycasts = true;
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            Dialog_box_UI.alpha = 0;
            Dialog_box_UI.interactable = false;
            Dialog_box_UI.blocksRaycasts = false;
            if (!door_toggle)
            {
                Time.timeScale = 1;
                StartMenu.Instance.end_trig();
            }
            else
            {
                GameObject[] roots = GetDontDestroyOnLoadObjects();
                Stats_Manager.Instance.done_tutorial = false;
                GameObject start_ui = roots.First((obj) => { return obj.name == "Start_UI"; });
                restart_pointer rp = start_ui.GetComponent<restart_pointer>();
                rp.restart_ui.SetActive(true);
                RestartMenu rmenu = rp.restart_ui.GetComponent<RestartMenu>();
                rmenu.Restart_but();
                rp.start_ui.SetActive(true);
                rp.start_ui.GetComponent<StartMenu>().bow.GetComponent<PlayerAimAndShoot>().isActive = false;
                Time.timeScale = 0;
            }
        }
    }
}
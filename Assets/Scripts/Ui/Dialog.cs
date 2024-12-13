using TMPro;
using UnityEngine;
using System.Collections;


public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    public GameObject continueButton;
    public CanvasGroup Dialog_box_UI;

    private int index;
    public static Dialog Instance;
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

    public void Start_trig()
    {
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
            Time.timeScale = 1;
            StartMenu.Instance.end_trig();
        }
    }
}
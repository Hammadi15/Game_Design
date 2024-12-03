using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public Sprite EmptyHeart;
    public Sprite FullHeart;
    public Image[] hearts;


    public void ChangeHealth(int amount)
    {
        //Takes current health adds it and sets current helth to be minus the added number
        Stats_Manager.Instance.CurrentHealth -= amount;
        update_health();
        if (Stats_Manager.Instance.CurrentHealth <= 0)
        {
            this.transform.parent.gameObject.SetActive(false);
        }
    }
    //Uppdates the display
    void update_health()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Stats_Manager.Instance.CurrentHealth)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < Stats_Manager.Instance.MaxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    //fire the function on start of game
    void Start()
    {
        update_health();
    }
}

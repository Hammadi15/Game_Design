using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{

    public int CurrentHealth;
    public int MaxHealth;

    public Sprite EmptyHeart;
    public Sprite FullHeart;
    public Image[] hearts;

    public void ChangeHealth(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < CurrentHealth)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < MaxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    void OnDisable()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < CurrentHealth)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < MaxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}

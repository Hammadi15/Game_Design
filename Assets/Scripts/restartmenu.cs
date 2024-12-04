using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public Object Restart_to;
    public GameObject player;
    public void Restart_but()
    {
        gameObject.SetActive(false);
        player.SetActive(true);
        Experience_Manager.Instance.reset_all();
        Stats_Manager.Instance.CurrentHealth = Stats_Manager.Instance.MaxHealth;
        player.GetComponentInChildren<Player_Health>().ChangeHealth(0);
        if (SceneManager.GetActiveScene().name != Restart_to.name)
        {
            SceneManager.LoadScene(Restart_to.name);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

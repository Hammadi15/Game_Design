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
        Stats_Manager.Instance.Restart();
        player.GetComponentInChildren<Player_Health>().ChangeHealth(0);
        player.GetComponentInChildren<PlayerAimAndShoot>().BulletCount = 10;
        if (SceneManager.GetActiveScene().name != Restart_to.name)
        {
            SceneManager.LoadScene(Restart_to.name);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Quit_but()
    {
        Application.Quit();
    }

}

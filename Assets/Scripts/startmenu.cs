using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject player;
    public void Start_but()
    {
        gameObject.SetActive(false);
        Player_Movment pm = player.GetComponent<Player_Movment>();
        pm.enabled_move = true;
    }
    public void Quit_but()
    {
        Application.Quit();
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

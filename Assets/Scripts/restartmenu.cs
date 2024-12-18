using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public Object Restart_to;
    public GameObject player;
    public GameObject timer;
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
    public void Restart_but()
    {
        //disables the current game object
        gameObject.SetActive(false);
        //enables the current game object
        player.SetActive(true);
        //resets all xp and levels from the Experience_Manager
        Experience_Manager.Instance.reset_all();
        //resets everything used by the player
        Stats_Manager.Instance.Restart();
        //forces a reset of the players health UI
        player.GetComponentInChildren<Player_Health>().ChangeHealth(0);
        GameObject[] roots = GetDontDestroyOnLoadObjects();
        GameObject wpUI = roots.First((obj) => { return obj.name == "Weapon_Switcher_UI"; });
        wpUI.GetComponentInChildren<ActiveInventory>().sword_weapon.canAttack = true;
        wpUI.GetComponentInChildren<ActiveInventory>().ToggleActiveSlot(1, true);
        //resets all of the arrows to the default value
        player.GetComponentInChildren<PlayerAimAndShoot>().BulletCount = 10;
        player.GetComponent<doormgr_pointer>().pointer.SetActive(true);
        Stats_Manager.Instance.TimePlayed = 0;
        Stats_Manager.Instance.Timestop = false;
        //checks if the current scene isn't the scene that we are suppose to reset to and based on that loads the reset scene or tries to reload the current scene if it is the reset to scene
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

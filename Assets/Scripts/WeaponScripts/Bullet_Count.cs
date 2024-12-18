using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet_Count : MonoBehaviour
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
    public bool ShouldNotDissaper = false;
    private GameObject wpUI;
    void Start()
    {
        GameObject[] roots = GetDontDestroyOnLoadObjects();
        wpUI = roots.First((obj) => { return obj.name == "Weapon_Switcher_UI"; });
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wpUI.GetComponentInChildren<ActiveInventory>().ToggleActiveSlot(1, true);
            collision.gameObject.GetComponentInChildren<PlayerAimAndShoot>().BulletCount += 5;
            if (!ShouldNotDissaper)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}


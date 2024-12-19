using UnityEngine;
using UnityEngine.SceneManagement;
public class load_dontdestroy : MonoBehaviour
{
    public static load_dontdestroy Instance;
    private void Awake()
    {
        //causes the gameObject to go into another scene that doesn't get unloaded when switching scenes
        //switching scenes causes Switched_area to fire 
        //there can't be several instances of this script to exist 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("dontdestroy", LoadSceneMode.Additive);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

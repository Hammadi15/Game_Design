using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_tele : MonoBehaviour
{
    public string scene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene);
        }
    }
}

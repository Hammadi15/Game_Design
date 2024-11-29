using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_tele : MonoBehaviour
{
    public Object scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset_script : MonoBehaviour
{
    public Object to_scene;
    void Awake()
    {
        SceneManager.LoadScene(to_scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

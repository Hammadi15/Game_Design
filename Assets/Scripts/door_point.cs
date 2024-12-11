using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door_point : MonoBehaviour
{
    public GameObject door;

    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "jack_Boss_Room")
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        Vector2 dir = (transform.position - door.transform.position).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg);
        transform.localScale = new Vector3(transform.parent.transform.localScale.x, 1, 1);
    }
}

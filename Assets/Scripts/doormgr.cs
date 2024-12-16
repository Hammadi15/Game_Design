using System.Linq;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doormgr : MonoBehaviour
{
    public GameObject player;
    public GameObject player_camera;
    public static Doormgr Instance;
    private void Awake()
    {
        //causes the gameObject to go into another scene that doesn't get unloaded when switching scenes
        DontDestroyOnLoad(gameObject);
        //switching scenes causes Switched_area to fire 
        SceneManager.activeSceneChanged += Switched_area;
        //there can't be several instances of this script to exist 
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Switched_area(Scene prev, Scene next)
    {
        //grabs all root GameObjects from the next scene and then tries to find the first GameObject called "Grid"
        GameObject[] roots = next.GetRootGameObjects();
        GameObject grid = roots.First((obj) => { return obj.name == "Grid"; });
        
        //grabs the Door_pointer component from the GameObject we just got
        Door_pointer door_pointer = grid.GetComponent<Door_pointer>();
        
        //sets the position of the player based on the transform inside of Spawn_point var 
        Vector3 spawn = door_pointer.Spawn_point.transform.position;
        player.transform.position = new Vector3(spawn.x, spawn.y, spawn.z);
        
        //sets the CinemachineConfiner inside of the player camera to the camera bounds of the grid
        CinemachineConfiner2D CinemachineConfiner = player_camera.GetComponent<CinemachineConfiner2D>();
        PolygonCollider2D PolygonCollider = door_pointer.Camera_Collider.GetComponent<PolygonCollider2D>();
        CinemachineConfiner.BoundingShape2D = PolygonCollider;
        GameObject door = roots.First((obj) => { return obj.name == "door"; });
        player.GetComponentInChildren<door_point>().door = door;
    }
}

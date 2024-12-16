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
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += Switched_area;
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
        GameObject[] roots = next.GetRootGameObjects();
        GameObject grid = roots.First((obj) => { return obj.name == "Grid"; });
        Door_pointer door_pointer = grid.GetComponent<Door_pointer>();
        Vector3 spawn = door_pointer.Spawn_point.transform.position;
        player.transform.position = new Vector3(spawn.x, spawn.y, spawn.z);
        PolygonCollider2D PolygonCollider = door_pointer.Camera_Collider.GetComponent<PolygonCollider2D>();
        CinemachineConfiner2D CinemachineConfiner = player_camera.GetComponent<CinemachineConfiner2D>();
        CinemachineConfiner.BoundingShape2D = PolygonCollider;
    }
}
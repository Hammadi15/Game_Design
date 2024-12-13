using UnityEngine;

public class Enemy_manager : MonoBehaviour
{
    public int enemy_count;
    public GameObject door;
    public static Enemy_manager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //finds all GameObjects that has the tag "Enemy" and sets the enemy_count to the length the responds
        enemy_count = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_count <= 0)
        {
            door.SetActive(true);
        }
    }
}

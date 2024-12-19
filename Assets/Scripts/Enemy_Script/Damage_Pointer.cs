using Unity.VisualScripting;
using UnityEngine;

public class Damage_Pointer : MonoBehaviour
{
    public Vector2 Spawnpoint;
    Vector3 Spawn = new(0, 0, 0);
    private float Timer = 2f;
    void Update()
    {
        Spawn.y += 0.01f;
        transform.position = (Vector3)Spawnpoint + Spawn;
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}

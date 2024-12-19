using UnityEngine;

public class door_point : MonoBehaviour
{
    public GameObject door;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 dir = (transform.position - door.transform.position).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        transform.localScale = new Vector3(transform.parent.transform.localScale.x, 1, 1);
    }
}

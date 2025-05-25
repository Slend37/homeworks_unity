using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 pose;
    private bool direction = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pose = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - pose.x) >= 2)
        {
            direction = false;
        }
        if ((transform.position.x - pose.x) < 0)
        {
            direction = true;
        }
        transform.Translate(new Vector3(2 * (direction ? 1 : -1), 0, 0) * Time.deltaTime);
    }
}

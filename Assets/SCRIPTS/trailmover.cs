using UnityEngine;

public class FollowEarth : MonoBehaviour
{
    public Transform earth;
    public float speed = 40f;

    void Update()
    {
        if (earth != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                earth.position,
                speed * Time.deltaTime
            );
        }
    }
}
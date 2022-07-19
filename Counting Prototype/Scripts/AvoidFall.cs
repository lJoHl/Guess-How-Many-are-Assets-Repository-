using UnityEngine;

public class AvoidFall : MonoBehaviour
{
    // Positions the figure at the value 0.5 of the y-axis when it falls off the map
    private void Update()
    {
        if (transform.position.y < 0)
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
}

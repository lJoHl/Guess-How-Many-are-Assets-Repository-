using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidFall : MonoBehaviour
{
    private void Start()
    {
        
    }


    private void Update()
    {
        if (transform.position.y < 0)
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
}

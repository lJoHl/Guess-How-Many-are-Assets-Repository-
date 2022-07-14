using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresCollision : MonoBehaviour
{
    private AudioSource figuresAudio;

    private bool hasSounded;


    private void Start()
    {
        figuresAudio = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Sphere" & collision.gameObject.tag != "Cube" & collision.gameObject.tag != "Cylinder" & !hasSounded)
        {
            figuresAudio.Play();
            hasSounded = true;
        }
    }
}

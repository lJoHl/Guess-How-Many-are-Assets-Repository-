using UnityEngine;

public class FiguresCollision : MonoBehaviour
{
    private AudioSource figuresAudio;

    private bool hasSounded;


    private void Start()
    {
        figuresAudio = GetComponent<AudioSource>();
    }


    // Makes figures play a sound when they collide, the sound only plays once
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Sphere" & collision.gameObject.tag != "Cube" & collision.gameObject.tag != "Cylinder" & !hasSounded)
        {
            figuresAudio.Play();
            hasSounded = true;
        }
    }
}

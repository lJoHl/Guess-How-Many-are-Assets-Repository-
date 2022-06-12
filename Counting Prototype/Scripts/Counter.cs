using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int count = 0;
    private int cubeCount = 0;
    private int sphereCount = 0;
    private int cylinderCount = 0;

    private void Start()
    {
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Cube":
                cubeCount++;
                break;

            case "Sphere":
                sphereCount++;
                break;

            case "Cylinder":
                cylinderCount++;
                break;
        }

        count += 1;
        CounterText.text = $"Count: {count}, Cubes: {cubeCount}, Spheres: {sphereCount}, Cylinders: {cylinderCount}";
    }


    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Cube":
                cubeCount--;
                break;

            case "Sphere":
                sphereCount--;
                break;

            case "Cylinder":
                cylinderCount--;
                break;
        }

        count -= 1;
        CounterText.text = $"Count: {count}, Cubes: {cubeCount}, Spheres: {sphereCount}, Cylinders: {cylinderCount}";
    }
}

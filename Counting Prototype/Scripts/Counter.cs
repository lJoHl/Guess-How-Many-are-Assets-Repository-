using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI spheresText;
    [SerializeField] private TextMeshProUGUI cubesText;
    [SerializeField] private TextMeshProUGUI cylindersText;
    [SerializeField] private TextMeshProUGUI totalText;

    private string defaultSpheresText;
    private string defaultCubesText;
    private string defaultCylindersText;
    private string defaultTotalText;

    private int cubeCount = 0;
    private int sphereCount = 0;
    private int cylinderCount = 0;
    private int totalCount = 0;

    private bool isOnTriggerEnter = false;


    private void Start()
    {
        defaultSpheresText = spheresText.text;
        defaultCubesText = cubesText.text;
        defaultCylindersText = cylindersText.text;
        defaultTotalText = totalText.text;
    }


    private void OnTriggerEnter(Collider other)
    {
        isOnTriggerEnter = true;

        ControlFiguresCount(other);
    }


    private void OnTriggerExit(Collider other)
    {
        isOnTriggerEnter = false;

        ControlFiguresCount(other);
    }


    private void ControlFiguresCount(Collider other)
    {
        switch (other.tag)
        {
            case "Sphere":
                sphereCount += UpdateCount(sphereCount, spheresText, defaultSpheresText);
                break;

            case "Cube":
                cubeCount += UpdateCount(cubeCount, cubesText, defaultCubesText);
                break;

            case "Cylinder":
                cylinderCount += UpdateCount(cylinderCount, cylindersText, defaultCylindersText);
                break;
        }

        totalCount += UpdateCount(totalCount, totalText, defaultTotalText);
    }


    private int UpdateCount(int figureCount, TextMeshProUGUI figureText, string defaultFigureText)
    {
        int figuresValue = isOnTriggerEnter ? 1 : -1;

        figureText.text = $"{defaultFigureText} \t {figureCount + figuresValue}";

        return figuresValue;
    }
}
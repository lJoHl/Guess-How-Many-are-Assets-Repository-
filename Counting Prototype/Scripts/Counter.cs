using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private GameManager gameManager;
    private BetManager betManager;

    /*
    [SerializeField] private TextMeshProUGUI spheresText;
    [SerializeField] private TextMeshProUGUI cubesText;
    [SerializeField] private TextMeshProUGUI cylindersText;
    [SerializeField] private TextMeshProUGUI totalText;

    private string defaultSpheresText;
    private string defaultCubesText;
    private string defaultCylindersText;
    private string defaultTotalText;
    */

    public int cubeCount = 0;  // ubyte
    public int sphereCount = 0; // ubyte
    public int cylinderCount = 0; // ubyte
    public int totalCount = 0; // ubyte

    private bool isOnTriggerEnter = false;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        betManager = GameObject.Find("BetManager").GetComponent<BetManager>();
        /*
        defaultSpheresText = spheresText.text;
        defaultCubesText = cubesText.text;
        defaultCylindersText = cylindersText.text;
        defaultTotalText = totalText.text;
        */
    }


    private void OnTriggerEnter(Collider other)
    {
        isOnTriggerEnter = true;

        ControlFiguresCount(other);
        UpdateCountersColor();
    }


    private void OnTriggerExit(Collider other)
    {
        isOnTriggerEnter = false;

        ControlFiguresCount(other);
        UpdateCountersColor();
    }


    private void ControlFiguresCount(Collider other)
    {
        switch (other.tag)
        {
            case "Sphere":
                sphereCount += UpdateCount(sphereCount, betManager.spheresAmount);
                break;

            case "Cube":
                cubeCount += UpdateCount(cubeCount, betManager.cubesAmount);
                break;

            case "Cylinder":
                cylinderCount += UpdateCount(cylinderCount, betManager.cylindersAmount);
                break;
        }

        totalCount += UpdateCount(totalCount, betManager.totalAmount);
    }


    private int UpdateCount(int figureCount, TextMeshProUGUI figureText)
    {
        int figuresValue = isOnTriggerEnter ? 1 : -1;

        figureText.text = (figureCount + figuresValue).ToString();

        return figuresValue;
    }


    private void UpdateCountersColor()
    {
        gameManager.CompareCounters(betManager.bettedSpheres, sphereCount, betManager.spheresAmount);
        gameManager.CompareCounters(betManager.bettedCubes, cubeCount, betManager.cubesAmount);
        gameManager.CompareCounters(betManager.bettedCylinders, cylinderCount, betManager.cylindersAmount);
        gameManager.CompareCounters(betManager.totalBet, totalCount, betManager.totalAmount);
    }
}
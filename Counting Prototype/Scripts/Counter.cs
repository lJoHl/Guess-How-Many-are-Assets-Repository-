using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private GameManager gameManager;
    private BetManager betManager;

    public int cubeCount = 0;
    public int sphereCount = 0;
    public int cylinderCount = 0;
    public int totalCount = 0;

    private bool isOnTriggerEnter = false;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        betManager = GameObject.Find("BetManager").GetComponent<BetManager>();
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


    // Updates the counter taking into account the type of figure that collided with the box
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


    // Updates the counter taking into account if the figure entered or left the box
    private int UpdateCount(int figureCount, TextMeshProUGUI figuresAmount)
    {
        int figuresValue = isOnTriggerEnter ? 1 : -1;

        figuresAmount.text = (figureCount + figuresValue).ToString();

        return figuresValue;
    }


    // Updates the color of the counter text
    private void UpdateCountersColor()
    {
        gameManager.CompareCounters(betManager.bettedSpheres, sphereCount, betManager.spheresAmount);
        gameManager.CompareCounters(betManager.bettedCubes, cubeCount, betManager.cubesAmount);
        gameManager.CompareCounters(betManager.bettedCylinders, cylinderCount, betManager.cylindersAmount);
        gameManager.CompareCounters(betManager.totalBet, totalCount, betManager.totalAmount);
    }
}
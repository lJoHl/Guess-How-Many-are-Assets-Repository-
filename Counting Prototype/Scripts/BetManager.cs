using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BetManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI spheresAmount;
    private int bettedSpheres = 0; //usar ubyte

    [SerializeField] private TextMeshProUGUI cubesAmount;
    private int bettedCubes = 0; //usar ubyte

    [SerializeField] private TextMeshProUGUI cylindersAmount;
    private int bettedCylinders = 0; //usar ubyte

    [SerializeField] private TextMeshProUGUI totalAmount;
    private int totalBet = 0; //int esta bien

    private int maxBet = 99; //usar ubyte
    private int minBet = 0; //usar ubyte


    public void selectButton(FigureButton figureButton, bool isAnIncrease)
    {
        switch (figureButton)
        {
            case FigureButton.Sphere:
                bettedSpheres += ControlBet(bettedSpheres, spheresAmount, isAnIncrease);
                break;

            case FigureButton.Cube:
                bettedCubes += ControlBet(bettedCubes, cubesAmount, isAnIncrease);
                break;

            case FigureButton.Cylinder:
                bettedCylinders += ControlBet(bettedCylinders, cylindersAmount, isAnIncrease);
                break;
        }
    }


    private int ControlBet(int bettedFigures, TextMeshProUGUI figuresAmount, bool isAnIncrease)
    {
        int valueToAdd = 0;

        if (isAnIncrease)
        {
            if (bettedFigures < maxBet)
            {
                valueToAdd++;
                totalBet++;
            }
        }
        else
        {
            if (bettedFigures > minBet)
            {
                valueToAdd--;
                totalBet--;
            }
        }

        figuresAmount.text = (bettedFigures + valueToAdd).ToString();
        totalAmount.text = totalBet.ToString();

        return valueToAdd;
    }
}

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
                bettedSpheres += ControlBet(bettedSpheres, isAnIncrease); //evitar repetir la llamada betted figures
                UpdateBet(bettedSpheres, spheresAmount);  //evitar repetir la llamada betted figures
                break;

            case FigureButton.Cube:
                bettedCubes += ControlBet(bettedCubes, isAnIncrease);
                UpdateBet(bettedCubes, cubesAmount);
                break;

            case FigureButton.Cylinder:
                bettedCylinders += ControlBet(bettedCylinders, isAnIncrease);
                UpdateBet(bettedCylinders, cylindersAmount);
                break;
        }
    }


    private int ControlBet(int bettedFigures, bool isAnIncrease)
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

        return valueToAdd;
    }


    private void UpdateBet(int bettedFigures, TextMeshProUGUI figuresAmount)
    {
        figuresAmount.text = bettedFigures.ToString();
        totalAmount.text = totalBet.ToString();
    }
}

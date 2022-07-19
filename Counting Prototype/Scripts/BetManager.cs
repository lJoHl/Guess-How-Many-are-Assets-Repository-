using TMPro;
using UnityEngine;


public class BetManager : MonoBehaviour
{
    public TextMeshProUGUI spheresAmount;
    public int bettedSpheres = 0;

    public TextMeshProUGUI cubesAmount;
    public int bettedCubes = 0;

    public TextMeshProUGUI cylindersAmount;
    public int bettedCylinders = 0;

    public TextMeshProUGUI totalAmount;
    public int totalBet = 0;

    private int maxBet = 99;
    private int minBet = 0;


    // Increases or decreases the bet value depending on the figure to which the pressed button belongs
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

            default:
                ControlBet(totalBet, totalAmount, isAnIncrease);
                break;
        }
    }


    // Increases or decreases the value bet depending on the button that has been pressed
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

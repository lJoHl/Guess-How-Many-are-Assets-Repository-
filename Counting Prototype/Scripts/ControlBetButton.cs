using UnityEngine;
using UnityEngine.UI;

public enum FigureButton { Sphere, Cube, Cylinder, None }

public class ControlBetButton : MonoBehaviour
{
    [SerializeField] private FigureButton figureButton;

    private BetManager betManager;

    private Button button;

    [SerializeField] private bool isAnIncrease;



    private void Start()
    {
        betManager = GameObject.Find("BetManager").GetComponent<BetManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(setTheBet);
    }


    private void setTheBet()
    {
        betManager.selectButton(figureButton, isAnIncrease);
    }
}

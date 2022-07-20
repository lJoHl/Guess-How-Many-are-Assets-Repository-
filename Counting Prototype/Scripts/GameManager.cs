using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private BetManager betManager;
    private Counter counter;

    private ResultTextController resultTextController;

    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject gameCounters;
    [SerializeField] private GameObject betElements;

    [SerializeField] private Button moreFigures;
    [SerializeField] private Button betAgain;

    [SerializeField] private AudioSource finalScreenAudio;

    private int gameMode;

    private int lowBets = 0;
    private int highBets = 0;
    private int matchingBets = 0;


    private void Start()
    {
        betManager = GameObject.Find("BetManager").GetComponent<BetManager>();
        counter = GameObject.Find("Box").GetComponent<Counter>();

        resultTextController = GameObject.Find("ResultText").GetComponent<ResultTextController>();
    }


    public void StartGame(int numberOfCounters)
    {
        gameMode = numberOfCounters;

        titleScreen.SetActive(false);
        ActivateGameModeElements(gameCounters.transform);
        ActivateGameModeElements(betElements.transform);
    }


    // Activates elements depending on the game mode
    private void ActivateGameModeElements(Transform parent)
    {
        parent.gameObject.SetActive(true);

        foreach (Transform child in parent)
        {
            if (child.childCount > 0)
                ActivateGameModeElements(child);

            switch (child.tag)
            {
                case "OnlyIn1CounterModeElement":
                    child.gameObject.SetActive(gameMode == 1);
                    break;

                case "OnlyIn4CountersModeElement":
                    child.gameObject.SetActive(gameMode == 4);
                    break;

                default:
                    child.gameObject.SetActive(true);
                    break;
            }
        }
    }


    public void StartBet()
    {
        betElements.SetActive(false);

        moreFigures.gameObject.SetActive(false);
        betAgain.gameObject.SetActive(false);

        resultTextController.SetCurrentTextToAnEmptyString();

        if (counter.totalCount == 0)
        {
            betManager.spheresAmount.text = "0";
            betManager.cubesAmount.text = "0";
            betManager.cylindersAmount.text = "0";
            betManager.totalAmount.text = "0";
        }

        StartCoroutine(SetFinalScreen(5));
    }


    // Configures end screen elements
    private IEnumerator SetFinalScreen(int gameTime)
    {
        yield return new WaitForSeconds(gameTime);


        if (gameMode == 4)
        {
            CompareCounters(betManager.bettedSpheres, counter.sphereCount);
            CompareCounters(betManager.bettedCubes, counter.cubeCount);
            CompareCounters(betManager.bettedCylinders, counter.cylinderCount);
        }
        CompareCounters(betManager.totalBet, counter.totalCount);


        if (matchingBets == gameMode)
        {
            resultTextController.ControlText(false, true);

            finalScreenAudio.pitch = 2;
        }
        else if (highBets == gameMode | lowBets == 0)
        {
            resultTextController.ControlText(true, false);

            moreFigures.gameObject.SetActive(true);
            finalScreenAudio.pitch = 1;
        }
        else
        {
            resultTextController.ControlText(false, false);

            finalScreenAudio.pitch = .5f;
        }


        betAgain.gameObject.SetActive(true);
        finalScreenAudio.Play();

        lowBets = 0;
        highBets = 0;
        matchingBets = 0;
    }

    // Defines the state of the counter
    private void CompareCounters(int bettedFigures, int figuresCount)
    {
        if (bettedFigures < figuresCount)
            lowBets++;
        else if (bettedFigures > figuresCount)
            highBets++;
        else
            matchingBets++;
    }


    // Defines the color of the counter text
    public void CompareCounters(int bettedFigures, int figuresCount, TextMeshProUGUI figuresAmount)
    {
        if (bettedFigures < figuresCount)
            figuresAmount.color = Color.red;
        else if (bettedFigures > figuresCount)
            figuresAmount.color = Color.yellow;
        else
            figuresAmount.color = Color.green;
    }


    // Restart the game
    public void BetAgainFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
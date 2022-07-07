using System.Collections;
using System.Collections.Generic;
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

    private bool isGameActive = false;

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
        isGameActive = true;
        gameMode = numberOfCounters;

        titleScreen.SetActive(false);
        GetChildrenTags(gameCounters.transform);
        GetChildrenTags(betElements.transform);
    }


    private void GetChildrenTags(Transform parent)  // cambiar el nombre del metodo
    {
        parent.gameObject.SetActive(true);

        foreach (Transform child in parent)
        {
            if (child.childCount > 0)
                GetChildrenTags(child);

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

        StartCoroutine(SetFinalScreen(5));
    }


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


        if (highBets == gameMode)
        {
            resultTextController.ControlText(true, false);
            moreFigures.gameObject.SetActive(true);
        }
        else if (matchingBets == gameMode)
            resultTextController.ControlText(false, true);
        else
            resultTextController.ControlText(false, false);


        betAgain.gameObject.SetActive(true);

        lowBets = 0;
        highBets = 0;
        matchingBets = 0;
    }

    private void CompareCounters(int bettedFigures, int figuresCount)
    {
        if (bettedFigures < figuresCount)
            lowBets++;
        else if (bettedFigures > figuresCount)
            highBets++;
        else
            matchingBets++;
    }


    public void BetAgainFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

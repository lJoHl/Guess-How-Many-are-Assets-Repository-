using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private BetManager betManager;
    private Counter counter;

    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject gameCounters;
    [SerializeField] private GameObject betElements;

    private bool isGameActive = false;


    private void Start()
    {
        betManager = GameObject.Find("BetManager").GetComponent<BetManager>();
        counter = GameObject.Find("Box").GetComponent<Counter>();
    }


    public void StartGame(int numberOfCounters)
    {
        isGameActive = true;

        titleScreen.SetActive(false);
        GetChildrenTags(gameCounters.transform, numberOfCounters);
        GetChildrenTags(betElements.transform, numberOfCounters);
    }


    private void GetChildrenTags(Transform parent, int gameMode)  // cambiar el nombre del metodo
    {
        parent.gameObject.SetActive(true);

        foreach (Transform child in parent)
        {
            if (child.childCount > 0)
                GetChildrenTags(child, gameMode);

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

        StartCoroutine(CompareCounters(5));
    }


    private IEnumerator CompareCounters(int gameTime)
    {
        yield return new WaitForSeconds(gameTime);

        if (betManager.totalBet == counter.totalCount)
        {
            Debug.Log("You win");
        }
        else
        {
            Debug.Log("You lose");
        }
    }
}

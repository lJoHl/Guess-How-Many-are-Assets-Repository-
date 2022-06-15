using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGameActive = false;

    [SerializeField] private GameObject betElements;

    [SerializeField] private Button betButton;


    public void StartGame()
    {
        isGameActive = true;
        betElements.SetActive(false);
    }
}

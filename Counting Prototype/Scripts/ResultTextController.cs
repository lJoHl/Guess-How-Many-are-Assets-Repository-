using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultTextController : MonoBehaviour
{
    private TextMeshProUGUI resultText;

    [SerializeField] private ParticleSystem sparksParticles;

    [SerializeField] private List<string> textToDisplay = new List<string>();
    
    private float timeToNextText;

    private int currentText;  // ubyte
    

    private void Start()
    {
        resultText = GetComponent<TextMeshProUGUI>();

        timeToNextText = 0.0f;
        currentText = textToDisplay.Count-1;
    }


    private void Update()
    {
        if (currentText == 0 | currentText == 1)
        {
            timeToNextText += Time.deltaTime;

            if (timeToNextText > 1.5f)
            {
                timeToNextText = 0.0f;

                if (currentText == 1)
                    currentText = 0;
                else
                    currentText++;
            }

            sparksParticles.Play();
        }
        else
        {
            sparksParticles.Stop();
        }

        resultText.text = textToDisplay[currentText];
    }


    public void ControlText(bool isAFullHighBet, bool winner)
    {
        currentText = winner ? 0 : isAFullHighBet ? 3 : 2;
    }

    public void SetCurrentTextToAnEmptyString()
    {
        currentText = textToDisplay.Count-1;
    }
}
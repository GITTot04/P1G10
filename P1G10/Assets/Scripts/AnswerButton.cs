using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    GameObject feedbackText;
    GameObject gameController;
    public string buttonValue;
    private void Start()
    {
        feedbackText = GameObject.Find("AnswerFeedbackText");
        gameController = GameObject.Find("GameMaster");
    }
    public void Answer()
    {
        if (buttonValue == gameController.GetComponent<GameController>().currentAnswer)
        {
            feedbackText.GetComponent<TextMeshProUGUI>().text = "Korrekt!";
        }
        else
        {
            feedbackText.GetComponent<TextMeshProUGUI>().text = "Prøv igen!";
        }
        gameController.GetComponent<GameController>().LoadNewValues();
    }
}

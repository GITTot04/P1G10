using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    GameObject feedbackText;
    GameObject gameController;
    GameObject healthBar;
    public string buttonValue;
    private void Start()
    {
        feedbackText = GameObject.Find("AnswerFeedbackText");
        gameController = GameObject.Find("GameMaster");
        healthBar = GameObject.Find("Healthbar");
    }
    public void Answer()
    {
        if (healthBar.GetComponent<HealtbarScript>().currentHealth != 0)
        {
            if (buttonValue == gameController.GetComponent<GameController>().currentAnswer)
            {
                feedbackText.GetComponent<TextMeshProUGUI>().text = "Korrekt!";
            }
            else
            {
                healthBar.GetComponent<HealtbarScript>().currentHealth -= 1;
                healthBar.GetComponent<HealtbarScript>().TookDamage();
                if (healthBar.GetComponent<HealtbarScript>().currentHealth != 0)
                {
                    feedbackText.GetComponent<TextMeshProUGUI>().text = "Pr�v igen!";
                }
                else
                {
                    feedbackText.GetComponent<TextMeshProUGUI>().text = "�v!";
                }
            }
            if (healthBar.GetComponent<HealtbarScript>().currentHealth != 0)
            {
                gameController.GetComponent<GameController>().LoadNewValues();
            }
        }
    }
}

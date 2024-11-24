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
    GameObject player;
    public string buttonValue;
    private void Start()
    {
        feedbackText = GameObject.Find("AnswerFeedbackText");
        gameController = GameObject.Find("GameMaster");
        healthBar = GameObject.Find("Healthbar");
        player = GameObject.Find("Player");
    }
    public void Answer()
    {
        if (healthBar.GetComponent<HealtbarScript>().currentHealth != 0)
        {
            if (buttonValue == gameController.GetComponent<GameController>().currentAnswer)
            {
                feedbackText.GetComponent<TextMeshProUGUI>().text = "Korrekt!";
                player.GetComponent<PlayerScript>().DoDamage();
            }
            else
            {
                healthBar.GetComponent<HealtbarScript>().currentHealth -= 1;
                healthBar.GetComponent<HealtbarScript>().TookDamage();
                if (healthBar.GetComponent<HealtbarScript>().currentHealth != 0)
                {
                    feedbackText.GetComponent<TextMeshProUGUI>().text = "Prøv igen!";
                }
                else
                {
                    feedbackText.GetComponent<TextMeshProUGUI>().text = "Øv!";
                }
            }
            gameController.GetComponent<GameController>().LoadNewValues();
        }
    }
}

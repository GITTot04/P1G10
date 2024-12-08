using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AnswerButton : MonoBehaviour
{
    GameObject feedbackText;
    GameObject gameController;
    GameObject healthBar;
    GameObject player;
    public string buttonValue;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            feedbackText = GameObject.Find("AnswerFeedbackText");
            healthBar = GameObject.Find("Healthbar");
        }
        gameController = GameObject.Find("GameMaster");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Answer()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
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
        else
        {
            if (player.GetComponent<PlayerControllerJump>().HP != 0)
            {
                if (buttonValue == gameController.GetComponent<GameController>().currentAnswer)
                {
                    player.GetComponent<PlayerControllerJump>().goodJump();
                }
                else
                {
                    player.GetComponent<PlayerControllerJump>().badJump();
                }
                gameController.GetComponent<GameController>().LoadNewValues();
            }
        }
    }
}

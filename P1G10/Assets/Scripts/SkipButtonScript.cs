using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButtonScript : MonoBehaviour
{
    GameObject healthBar;
    GameObject player;
    GameObject gameController;
    private void Start()
    {
        gameController = GameObject.Find("GameMaster");
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            healthBar = GameObject.Find("Healthbar");
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public void Skip()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (healthBar.GetComponent<HealtbarScript>().currentHealth != 0 && gameController.GetComponent<GameController>().canSkip)
            {
                gameController.GetComponent<EndScreenScript>().AddSkippedAnswer();
                gameController.GetComponent<GameController>().LoadNewValues();
            }
        }
        else if (player.GetComponent<PlayerControllerJump>().HP != 0 && gameController.GetComponent<GameController>().canSkip)
        {
            gameController.GetComponent<EndScreenScript>().AddSkippedAnswer();
            gameController.GetComponent<GameController>().LoadNewValues();
            gameController.GetComponent<GameController>().PlayCoroutine();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayScript : MonoBehaviour
{
    GameObject gameController;
    GameObject healthBar;
    GameObject player;
    private void Awake()
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
    public void ReplaySounds()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (healthBar.GetComponent<HealtbarScript>().currentHealth != 0)
            {
                StartCoroutine(gameController.GetComponent<GameController>().PlayAudio());
            }
        }
        else
        {
            if (player.GetComponent<PlayerControllerJump>().HP != 0)
            {
                StartCoroutine(gameController.GetComponent<GameController>().PlayAudio());
            }
        }

    }
}

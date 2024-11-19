using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayScript : MonoBehaviour
{
    GameObject gameController;
    GameObject healthBar;
    private void Awake()
    {
        gameController = GameObject.Find("GameMaster");
        healthBar = GameObject.Find("Healthbar");
    }
    public void ReplaySounds()
    {
        if (healthBar.GetComponent<HealtbarScript>().currentHealth != 0)
        {
            StartCoroutine(gameController.GetComponent<GameController>().PlayAudio());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtbarScript : MonoBehaviour
{
    public Sprite emptyHealth;
    public int currentHealth = 3;
    GameObject restartButton;
    GameObject endscreenButton;
    private void Awake()
    {
        restartButton = GameObject.Find("RestartButton");
        endscreenButton = GameObject.Find("OpenEndscreenButton");
        restartButton.SetActive(false);
        endscreenButton.SetActive(false);
    }

    public void TookDamage()
    {
        switch (currentHealth)
        {
            case 2:
                transform.GetChild(2).GetComponent<Image>().sprite = emptyHealth;
                break;
            case 1:
                transform.GetChild(1).GetComponent<Image>().sprite = emptyHealth;
                break;
            case 0:
                transform.GetChild(0).GetComponent<Image>().sprite = emptyHealth;
                restartButton.SetActive(true);
                endscreenButton.SetActive(true);
                break;
        }
    }
}

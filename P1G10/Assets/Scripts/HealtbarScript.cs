using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtbarScript : MonoBehaviour
{
    public Sprite emptyHealth;
    public int currentHealth = 3;
    GameObject restartButton;
    private void Awake()
    {
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);
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
                break;
        }
    }
}

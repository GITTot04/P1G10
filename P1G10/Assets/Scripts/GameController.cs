using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    Soundbite currentFirstSound;
    Soundbite currentSecondSound;
    Soundbite currentThirdSound;
    GameObject firstSoundTextObject;
    GameObject secondSoundTextObject;
    GameObject thirdSoundTextObject;
    private void Awake()
    {
        firstSoundTextObject = GameObject.Find("FirstSoundText");
        secondSoundTextObject = GameObject.Find("SecondSoundText");
        thirdSoundTextObject = GameObject.Find("ThirdSoundText");
    }
    private void Start()
    {
        LoadNewValues();
    }
    public void LoadNewValues()
    {
        if (ActiveSounds.ActiveSoundsInfo.guessValue != 0)
        {
            currentFirstSound = ActiveSounds.ActiveSoundsInfo.FirstSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.FirstSound.Length)];
            while (currentFirstSound == null)
            {
                currentFirstSound = ActiveSounds.ActiveSoundsInfo.FirstSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.FirstSound.Length)];
            }
        }
        if (ActiveSounds.ActiveSoundsInfo.guessValue != 1)
        {
            currentSecondSound = ActiveSounds.ActiveSoundsInfo.SecondSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.SecondSound.Length)];
            while (currentSecondSound == null)
            {
                currentSecondSound = ActiveSounds.ActiveSoundsInfo.SecondSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.SecondSound.Length)];
            }
        }
        if (ActiveSounds.ActiveSoundsInfo.guessValue != 2)
        {
            currentThirdSound = ActiveSounds.ActiveSoundsInfo.ThirdSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.ThirdSound.Length)];
            while (currentThirdSound == null)
            {
                currentThirdSound = ActiveSounds.ActiveSoundsInfo.ThirdSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.ThirdSound.Length)];
            }
        }
        SetTextValues();
    }
    public void SetTextValues()
    {
        if (ActiveSounds.ActiveSoundsInfo.guessValue != 0)
        {
            firstSoundTextObject.GetComponent<TextMeshProUGUI>().text = currentFirstSound.value;
        }
        else
        {
            firstSoundTextObject.GetComponent<TextMeshProUGUI>().text = "_";
        }

        if (ActiveSounds.ActiveSoundsInfo.guessValue != 1)
        {
            secondSoundTextObject.GetComponent<TextMeshProUGUI>().text = currentSecondSound.value;
        }
        else
        {
            secondSoundTextObject.GetComponent<TextMeshProUGUI>().text = "_";
        }

        if (ActiveSounds.ActiveSoundsInfo.guessValue != 2)
        {
            thirdSoundTextObject.GetComponent<TextMeshProUGUI>().text = currentThirdSound.value + " I";
        }
        else
        {
            thirdSoundTextObject.GetComponent<TextMeshProUGUI>().text = "_ I";
        }
    }
}

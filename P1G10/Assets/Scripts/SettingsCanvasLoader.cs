using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCanvasLoader : MonoBehaviour
{
    void Start()
    {
        ActiveSounds.ActiveSoundsInfo.ChangeChildrenActivation();
        foreach (GameObject toggle in GameObject.FindGameObjectsWithTag("FirstSound"))
        {
            toggle.GetComponent<Toggle>().isOn = false;
            foreach (Soundbite activeSound in ActiveSounds.ActiveSoundsInfo.firstSound)
            {
                if (activeSound != null)
                {
                    if (toggle.GetComponent<Soundbite>().value == activeSound.value)
                    {
                        toggle.GetComponent<Toggle>().isOn = true;
                    }
                }
            }
        }
        foreach (GameObject toggle in GameObject.FindGameObjectsWithTag("SecondSound"))
        {
            toggle.GetComponent<Toggle>().isOn = false;
            foreach (Soundbite activeSound in ActiveSounds.ActiveSoundsInfo.secondSound)
            {
                if (activeSound != null)
                {
                    if (toggle.GetComponent<Soundbite>().value == activeSound.value)
                    {
                        toggle.GetComponent<Toggle>().isOn = true;
                    }
                }
            }
        }
        foreach (GameObject toggle in GameObject.FindGameObjectsWithTag("ThirdSound"))
        {
            toggle.GetComponent<Toggle>().isOn = false;
            foreach (Soundbite activeSound in ActiveSounds.ActiveSoundsInfo.thirdSound)
            {
                if (activeSound != null)
                {
                    if (toggle.GetComponent<Soundbite>().value == activeSound.value)
                    {
                        toggle.GetComponent<Toggle>().isOn = true;
                    }
                }
            }
        }
    }
}
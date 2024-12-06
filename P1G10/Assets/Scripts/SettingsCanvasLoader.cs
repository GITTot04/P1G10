using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCanvasLoader : MonoBehaviour
{
    void Start()
    {
        ActiveSounds.ActiveSoundsInfo.ChangeChildrenActivation();
        // NEDEUNDER VIRKER IKKE ENDNU
        /*
        foreach (GameObject toggle in GameObject.FindGameObjectsWithTag("FirstSound"))
        {
            toggle.GetComponent<Toggle>().isOn = false;
        }
        foreach (GameObject toggle in GameObject.FindGameObjectsWithTag("SecondSound"))
        {
            toggle.GetComponent<Toggle>().isOn = false;
        }
        foreach (GameObject toggle in GameObject.FindGameObjectsWithTag("ThirdSound"))
        {
            toggle.GetComponent<Toggle>().isOn = false;
        }
        */
    }
}
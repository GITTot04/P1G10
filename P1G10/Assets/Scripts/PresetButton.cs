using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PresetButton : MonoBehaviour
{
    public Soundbite[] firstSoundPreset = new Soundbite[20];
    public Soundbite[] secondSoundPreset = new Soundbite[3];
    public Soundbite[] thirdSoundPreset = new Soundbite[20];
    GameObject guessDropdown;
    GameObject voiceDropdown;
    private void Start()
    {
        guessDropdown = GameObject.Find("GuessDropdown");
        voiceDropdown = GameObject.Find("VoiceDropdown");
    }
    public void UpdateActiveSounds()
    {
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
        Array.Clear(ActiveSounds.ActiveSoundsInfo.firstSound, 0, ActiveSounds.ActiveSoundsInfo.firstSound.Length);
        Array.Clear(ActiveSounds.ActiveSoundsInfo.secondSound, 0, ActiveSounds.ActiveSoundsInfo.secondSound.Length);
        Array.Clear(ActiveSounds.ActiveSoundsInfo.thirdSound, 0, ActiveSounds.ActiveSoundsInfo.thirdSound.Length);
        int i = 0;
        foreach (Soundbite soundbite in firstSoundPreset)
        {
            if (soundbite != null)
            {
                ActiveSounds.ActiveSoundsInfo.firstSound[i] = soundbite;
                soundbite.GetComponent<Toggle>().isOn = true;
                i++;
            }
        }
        i = 0;
        foreach (Soundbite soundbite in secondSoundPreset)
        {
            if (soundbite != null)
            {
                ActiveSounds.ActiveSoundsInfo.secondSound[i] = soundbite;
                soundbite.GetComponentInParent<Toggle>().isOn = true;
                i++;
            }
        }
        i = 0;
        foreach (Soundbite soundbite in thirdSoundPreset)
        {
            if (soundbite != null)
            {
                ActiveSounds.ActiveSoundsInfo.thirdSound[i] = soundbite;
                soundbite.GetComponentInParent<Toggle>().isOn = true;
                i++;
            }
        }
        guessDropdown.GetComponent<TMP_Dropdown>().value = 2;
        voiceDropdown.GetComponent<TMP_Dropdown>().value = 2;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoiceDropdownScript : MonoBehaviour
{
    public void ChangeDropdownValue()
    {
        switch (GetComponent<TMP_Dropdown>().value)
        {
            case 0:
                ActiveSounds.ActiveSoundsInfo.voice = "M1";
                break;
            case 1:
                ActiveSounds.ActiveSoundsInfo.voice = "M2";
                break;
            case 2:
                ActiveSounds.ActiveSoundsInfo.voice = "F1";
                break;
            case 3:
                ActiveSounds.ActiveSoundsInfo.voice = "F2";
                break;
        } 
    }
}

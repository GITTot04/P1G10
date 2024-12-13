using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonScript : MonoBehaviour
{
    private void Start()
    {
        SaveSettings();
    }
    public void SaveSettings()
    {
        ActiveSounds.ActiveSoundsInfo.SaveActiveSounds();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonScript : MonoBehaviour
{
    public void SaveSettings()
    {
        ActiveSounds.ActiveSoundsInfo.SaveActiveSounds();
    }
}
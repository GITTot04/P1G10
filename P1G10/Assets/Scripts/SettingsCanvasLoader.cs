using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsCanvasLoader : MonoBehaviour
{
    void Start()
    {
        ActiveSounds.ActiveSoundsInfo.ChangeChildrenActivation();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessDropdownScript : MonoBehaviour
{
    public void ChangeDropdownValue()
    {
        ActiveSounds.ActiveSoundsInfo.guessValue = gameObject.GetComponent<TMP_Dropdown>().value;
    }
}

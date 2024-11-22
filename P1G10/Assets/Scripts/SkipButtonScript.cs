using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButtonScript : MonoBehaviour
{
    public void Skip()
    {
        GameObject.Find("GameMaster").GetComponent<GameController>().LoadNewValues();
    }
}

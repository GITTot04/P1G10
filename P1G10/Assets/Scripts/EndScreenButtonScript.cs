using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenButtonScript : MonoBehaviour
{
    GameObject endscreen;
    private void Awake()
    {
        endscreen = GameObject.Find("Endscreen");
    }
    public void OpenEndscreen()
    {
        GameObject.Find("GameMaster").GetComponent<EndScreenScript>().ActivateEndscreen();
    }
    public void CloseEndscreen()
    {
        endscreen.SetActive(false);
    }
}

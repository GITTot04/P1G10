using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActiveSounds : MonoBehaviour
{
    public static ActiveSounds ActiveSoundsInfo;
    public Soundbite[] firstSound = new Soundbite[20];
    public Soundbite[] secondSound = new Soundbite[3];
    public Soundbite[] thirdSound = new Soundbite[20];
    public GameObject[] children = new GameObject[10];
    public int guessValue = 0;
    public string voice = "M1";
    private void Awake()
    {
        if (ActiveSoundsInfo != null)
        {
            Destroy(gameObject);
            return;
        }
        ActiveSoundsInfo = this;
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }
    }
    public void SaveActiveSounds()
    {
        if (CheckFirstSoundToggles() && CheckSecondSoundToggles() && CheckThirdSoundToggles())
        {
            Array.Clear(firstSound, 0, firstSound.Length);
            Array.Clear(secondSound, 0, secondSound.Length);
            Array.Clear(thirdSound, 0, thirdSound.Length);
            int i = 0;
            int j = 0;
            int k = 0;
            foreach (GameObject FirstSoundToggle in GameObject.FindGameObjectsWithTag("FirstSound"))
            {
                if (FirstSoundToggle.GetComponent<Toggle>().isOn)
                {
                    firstSound[i] = FirstSoundToggle.GetComponent<Soundbite>();
                    Debug.Log(i);
                    i++;
                }
            }
            foreach (GameObject SecondSoundToggle in GameObject.FindGameObjectsWithTag("SecondSound"))
            {
                if (SecondSoundToggle.GetComponent<Toggle>().isOn)
                {
                    secondSound[j] = SecondSoundToggle.GetComponent<Soundbite>();
                    Debug.Log(j);
                    j++;
                }
            }
            foreach (GameObject ThirdSoundToggle in GameObject.FindGameObjectsWithTag("ThirdSound"))
            {
                if (ThirdSoundToggle.GetComponent<Toggle>().isOn)
                {
                    thirdSound[k] = ThirdSoundToggle.GetComponent<Soundbite>();
                    Debug.Log(k);
                    k++;
                }
            }
        }

    }
    public void ChangeChildrenActivation()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            foreach (GameObject child in children)
            {
                if (child != null)
                {
                    child.SetActive(true);
                }
            }
        }
        else
        {
            foreach (GameObject child in children)
            {
                if (child != null)
                {
                    child.SetActive(false);
                }
            }
        }
    }

    bool CheckFirstSoundToggles()
    {
        foreach (GameObject FirstSoundToggle in GameObject.FindGameObjectsWithTag("FirstSound"))
        {
            if (FirstSoundToggle.GetComponent<Toggle>().isOn)
            {
                return true;
            }
        }
        return false;
    }
    bool CheckSecondSoundToggles()
    {
        foreach (GameObject SecondSoundToggle in GameObject.FindGameObjectsWithTag("SecondSound"))
        {
            if (SecondSoundToggle.GetComponent<Toggle>().isOn)
            {
                return true;
            }
        }
        return false;
    }
    bool CheckThirdSoundToggles()
    {
        foreach (GameObject ThirdSoundToggle in GameObject.FindGameObjectsWithTag("ThirdSound"))
        {
            if (ThirdSoundToggle.GetComponent<Toggle>().isOn)
            {
                return true;
            }
        }
        return false;
    }
}
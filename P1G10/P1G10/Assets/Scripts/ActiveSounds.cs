using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActiveSounds : MonoBehaviour
{
    public static ActiveSounds ActiveSoundsInfo;
    // Fjern public fra disse arrays når testing er done
    public Soundbite[] FirstSound = new Soundbite[20];
    public Soundbite[] SecondSound = new Soundbite[3];
    public Soundbite[] ThirdSound = new Soundbite[20];
    public GameObject[] children = new GameObject[10];
    public int guessValue = 0;
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
            Array.Clear(FirstSound, 0, FirstSound.Length);
            Array.Clear(SecondSound, 0, SecondSound.Length);
            Array.Clear(ThirdSound, 0, ThirdSound.Length);
            int i = 0;
            int j = 0;
            int k = 0;
            foreach (GameObject FirstSoundToggle in GameObject.FindGameObjectsWithTag("FirstSound"))
            {
                if (FirstSoundToggle.GetComponent<Toggle>().isOn)
                {
                    FirstSound[i] = FirstSoundToggle.GetComponent<Soundbite>();
                    i++;
                }
            }
            foreach (GameObject SecondSoundToggle in GameObject.FindGameObjectsWithTag("SecondSound"))
            {
                if (SecondSoundToggle.GetComponent<Toggle>().isOn)
                {
                    SecondSound[j] = SecondSoundToggle.GetComponent<Soundbite>();
                    j++;
                }
            }
            foreach (GameObject ThirdSoundToggle in GameObject.FindGameObjectsWithTag("ThirdSound"))
            {
                if (ThirdSoundToggle.GetComponent<Toggle>().isOn)
                {
                    ThirdSound[k] = ThirdSoundToggle.GetComponent<Soundbite>();
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
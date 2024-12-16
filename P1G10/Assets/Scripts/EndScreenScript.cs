using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenScript : MonoBehaviour
{
    GameObject endscreen;
    GameController gameControllerScript;
    // 1200 is the current max amount of words (20*3*20)
    public string[] words = new string[1200];
    int[] wordsCorrect = new int[1200];
    int[] wordsIncorrect = new int[1200];
    int[] wordsSkipped = new int[1200];
    int[] wordsReplayed = new int[1200];
    void Start()
    {
        gameControllerScript = gameObject.GetComponent<GameController>();
        endscreen = GameObject.Find("Endscreen");
        endscreen.SetActive(false);
        FindActiveWords();
    }

    void FindActiveWords()
    {
        int i = 0;
        foreach (Soundbite sound0 in ActiveSounds.ActiveSoundsInfo.firstSound)
        {
            if (sound0 != null)
            {
                foreach (Soundbite sound1 in ActiveSounds.ActiveSoundsInfo.secondSound)
                {
                    if (sound1 != null)
                    {
                        foreach (Soundbite sound2 in ActiveSounds.ActiveSoundsInfo.thirdSound)
                        {
                            if (sound2 != null)
                            {
                                words[i] = sound0.value + sound1.value + sound2.value + "I";
                                i++;
                            }
                        }
                    }
                }
            }
        }
    }

    public void AddCorrectAnswer()
    {
        int i = 0;
        foreach (string word in words)
        {
            if (words[i] != "")
            {
                if (gameControllerScript.currentFirstSound.value + gameControllerScript.currentSecondSound.value + gameControllerScript.currentThirdSound.value + "I" == words[i])
                {
                    wordsCorrect[i]++;
                    return;
                }
            }
            i++;
        }
    }

    public void AddIncorrectAnswer()
    {
        int i = 0;
        foreach (string word in words)
        {
            if (words[i] != "")
            {
                if (gameControllerScript.currentFirstSound.value + gameControllerScript.currentSecondSound.value + gameControllerScript.currentThirdSound.value + "I" == words[i])
                {
                    wordsIncorrect[i]++;
                    return;
                }
            }
            i++;
        }
    }

    public void AddSkippedAnswer()
    {
        int i = 0;
        foreach (string word in words)
        {
            if (words[i] != "")
            {
                if (gameControllerScript.currentFirstSound.value + gameControllerScript.currentSecondSound.value + gameControllerScript.currentThirdSound.value + "I" == words[i])
                {
                    wordsSkipped[i]++;
                    return;
                }
            }
            i++;
        }
    }

    public void AddReplayedAnswer()
    {
        int i = 0;
        foreach (string word in words)
        {
            if (words[i] != "")
            {
                if (gameControllerScript.currentFirstSound.value + gameControllerScript.currentSecondSound.value + gameControllerScript.currentThirdSound.value + "I" == words[i])
                {
                    wordsReplayed[i]++;
                    return;
                }
            }
            i++;
        }
    }

    public void ActivateEndscreen()
    {
        string endText = "Lyd       Korrekt     Forkert     Sprunget over   Genspillet \n";
        int i = 0;
        foreach (string word in words)
        {
            if (word != "")
            {
                endText += word + "         " + wordsCorrect[i] + "                 " + wordsIncorrect[i] + "                   " + wordsSkipped[i] + "                     " + wordsReplayed[i] + "\n";
                i++;
            }
        }
        endscreen.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = endText;
        endscreen.SetActive(true);
    }
}

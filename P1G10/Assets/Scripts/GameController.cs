using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    Soundbite currentFirstSound;
    Soundbite currentSecondSound;
    Soundbite currentThirdSound;
    AudioClip currentFullSound;
    public string currentAnswer;
    GameObject firstSoundTextObject;
    GameObject secondSoundTextObject;
    GameObject thirdSoundTextObject;
    string audioFileName;
    AudioSource currentAudio;
    bool canPlay = true;
    GameObject ConsonantAnswerButtons;
    GameObject VowelAnswerButtons;
    private void Awake()
    {
        firstSoundTextObject = GameObject.Find("FirstSoundText");
        secondSoundTextObject = GameObject.Find("SecondSoundText");
        thirdSoundTextObject = GameObject.Find("ThirdSoundText");
        ConsonantAnswerButtons = GameObject.Find("ConsonantAnswerButtons");
        VowelAnswerButtons = GameObject.Find("VowelAnswerButtons");

    }
    private void Start()
    {
        currentAudio = GetComponent<AudioSource>();
        LoadNewValues();
        SetAnswerButtons();
        StartCoroutine(PlayAudio());

    }
    public void LoadNewValues()
    {
        currentFirstSound = ActiveSounds.ActiveSoundsInfo.firstSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.firstSound.Length)];
        while (currentFirstSound == null)
        {
            currentFirstSound = ActiveSounds.ActiveSoundsInfo.firstSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.firstSound.Length)];
        }
        if (ActiveSounds.ActiveSoundsInfo.guessValue == 0)
        {
            currentAnswer = currentFirstSound.value;
        }
        currentSecondSound = ActiveSounds.ActiveSoundsInfo.secondSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.secondSound.Length)];
        while (currentSecondSound == null)
        {
            currentSecondSound = ActiveSounds.ActiveSoundsInfo.secondSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.secondSound.Length)];
        }
        if (ActiveSounds.ActiveSoundsInfo.guessValue == 1)
        {
            currentAnswer = currentSecondSound.value;
        }
        currentThirdSound = ActiveSounds.ActiveSoundsInfo.thirdSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.thirdSound.Length)];
        while (currentThirdSound == null)
        {
            currentThirdSound = ActiveSounds.ActiveSoundsInfo.thirdSound[Random.Range(0, ActiveSounds.ActiveSoundsInfo.thirdSound.Length)];
        }
        if (ActiveSounds.ActiveSoundsInfo.guessValue == 2)
        {
            currentAnswer = currentThirdSound.value;
        }
        audioFileName = currentFirstSound.value + currentSecondSound.value + currentThirdSound.value + "i_";
        audioFileName = audioFileName.ToLower();
        audioFileName += ActiveSounds.ActiveSoundsInfo.voice;
        currentFullSound = Resources.Load <AudioClip>("Sounds/" + ActiveSounds.ActiveSoundsInfo.voice + "/" + audioFileName);
        Debug.Log("Kontrol Sounds/" + ActiveSounds.ActiveSoundsInfo.voice + "/" + audioFileName);
        SetTextValues();
    }

    public void SetTextValues()
    {
        if (ActiveSounds.ActiveSoundsInfo.guessValue != 0)
        {
            firstSoundTextObject.GetComponent<TextMeshProUGUI>().text = currentFirstSound.value;
        }
        else
        {
            firstSoundTextObject.GetComponent<TextMeshProUGUI>().text = "_";
        }

        if (ActiveSounds.ActiveSoundsInfo.guessValue != 1)
        {
            secondSoundTextObject.GetComponent<TextMeshProUGUI>().text = currentSecondSound.value;
        }
        else
        {
            secondSoundTextObject.GetComponent<TextMeshProUGUI>().text = "_";
        }

        if (ActiveSounds.ActiveSoundsInfo.guessValue != 2)
        {
            thirdSoundTextObject.GetComponent<TextMeshProUGUI>().text = currentThirdSound.value + " I";
        }
        else
        {
            thirdSoundTextObject.GetComponent<TextMeshProUGUI>().text = "_ I";
        }
        StopAllCoroutines();
        canPlay = true;
        StartCoroutine(PlayAudio());
    }

    public void SetAnswerButtons()
    {
        if (ActiveSounds.ActiveSoundsInfo.guessValue == 1)
        {
            ConsonantAnswerButtons.SetActive(false);
        }
        else
        {
            VowelAnswerButtons.SetActive(false);
        }
    }

    public IEnumerator PlayAudio()
    {
        if (canPlay)
        {
            canPlay = false;
            currentAudio.clip = currentFullSound;
            currentAudio.Play();
            yield return new WaitForSeconds(currentAudio.clip.length);
            canPlay = true;
        }
    }
}

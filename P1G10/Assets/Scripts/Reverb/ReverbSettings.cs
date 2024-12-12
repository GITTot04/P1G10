using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System;
using System.Linq;
using TMPro;

public class ReverbControl : MonoBehaviour
{
    public TMP_Dropdown audioReverbDropdown;
    private AudioReverbPreset[] allPresets;
    private const string ReverbPresetKey = "SelectedReverbPreset";

    void Start()
    {
        // Populate the dropdown and load the saved preset
        PopulateDropdown();
        LoadSavedPreset();

        // Add listener for the dropdown change
        audioReverbDropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Listen to scene load events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void PopulateDropdown()
    {
        allPresets = Enum.GetValues(typeof(AudioReverbPreset))
                         .Cast<AudioReverbPreset>()
                         .ToArray();

        var options = allPresets.Select(preset => preset.ToString()).ToList();

        audioReverbDropdown.ClearOptions();
        audioReverbDropdown.AddOptions(options);
    }

    void LoadSavedPreset()
    {
        int savedPresetIndex = PlayerPrefs.GetInt(ReverbPresetKey, 0);

        audioReverbDropdown.value = savedPresetIndex;

        ApplyReverbPreset(savedPresetIndex);
    }

    void OnDropdownValueChanged(int index)
    {
        PlayerPrefs.SetInt(ReverbPresetKey, index);
        PlayerPrefs.Save();

        ApplyReverbPreset(index);
    }

    void ApplyReverbPreset(int presetIndex)
    {
        AudioReverbFilter[] audioReverbFilters = FindObjectsOfType<AudioReverbFilter>();

        AudioReverbPreset selectedPreset = allPresets[presetIndex];

        foreach (var filter in audioReverbFilters)
        {
            filter.reverbPreset = selectedPreset;
        }

        Debug.Log("Applied Reverb Preset: " + selectedPreset);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyReverbPreset(audioReverbDropdown.value);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

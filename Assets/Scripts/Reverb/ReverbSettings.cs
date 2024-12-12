using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import SceneManagement
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
        // Get all possible reverb presets and populate the dropdown
        allPresets = Enum.GetValues(typeof(AudioReverbPreset))
                         .Cast<AudioReverbPreset>()
                         .ToArray();

        var options = allPresets.Select(preset => preset.ToString()).ToList();

        audioReverbDropdown.ClearOptions();
        audioReverbDropdown.AddOptions(options);
    }

    void LoadSavedPreset()
    {
        // Load the saved preset index (default to 0 if not found)
        int savedPresetIndex = PlayerPrefs.GetInt(ReverbPresetKey, 0);

        // Set the dropdown to the saved preset
        audioReverbDropdown.value = savedPresetIndex;

        // Apply the reverb preset immediately
        ApplyReverbPreset(savedPresetIndex);
    }

    void OnDropdownValueChanged(int index)
    {
        // Save the selected preset to PlayerPrefs
        PlayerPrefs.SetInt(ReverbPresetKey, index);
        PlayerPrefs.Save();

        // Apply the selected reverb preset
        ApplyReverbPreset(index);
    }

    void ApplyReverbPreset(int presetIndex)
    {
        // Find all AudioReverbFilter components in the scene
        AudioReverbFilter[] audioReverbFilters = FindObjectsOfType<AudioReverbFilter>();

        // Get the selected reverb preset
        AudioReverbPreset selectedPreset = allPresets[presetIndex];

        // Apply the selected preset to all found filters
        foreach (var filter in audioReverbFilters)
        {
            filter.reverbPreset = selectedPreset;
        }

        Debug.Log("Applied Reverb Preset: " + selectedPreset);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Apply the saved reverb preset when the new scene loads
        ApplyReverbPreset(audioReverbDropdown.value);
    }

    void OnDestroy()
    {
        // Unsubscribe from sceneLoaded when the object is destroyed to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

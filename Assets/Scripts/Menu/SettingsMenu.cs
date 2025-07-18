using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    public Toggle toggleFullScreen;

    Resolution[] resolutions;

    public void Start()
    {
        // Get all possible resolutions and delete duplicates resolutions
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        // Liste of resolutions
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        // Browse all available resolutions to create the options to be displayed
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Concatenates width and height as text
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            // If the resolution corresponds to the current screen resolution
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                // Save index
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Synchronise la checkbox avec le mode plein écran actuel
        toggleFullScreen.isOn = Screen.fullScreen;
    }

    // Volume control
    public void SetVolume(float volume)
    {
        // Sets the value of the “volume” parameter
        audioMixer.SetFloat("volume", volume);
    }

    // Full screen control
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    // Resolution control
    public void SetResolution(int resolutionIndex)
    {
        // Get resolution selected and keep full screen mode
        Resolution resolution = resolutions[resolutionIndex];
        // Apply the new resolution
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

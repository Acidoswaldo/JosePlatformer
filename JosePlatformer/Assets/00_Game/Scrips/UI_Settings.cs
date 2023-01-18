using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using Michsky.MUIP;

public class UI_Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionsDropdown;
    public TMP_Dropdown qualityDropdown;

    public Toggle fullscreentoggle;
    public SwitchManager switchManager;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider AudioSlider;
    Resolution[] resolutions;
    bool fullscreen;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
        fullscreen = Screen.fullScreen;
        if(fullscreentoggle) fullscreentoggle.isOn = fullscreen;
        if(switchManager) switchManager.isOn = fullscreen;

        audioMixer.GetFloat("MasterVolume", out float masterVolume);
        MasterSlider.value = masterVolume;

        audioMixer.GetFloat("MusicVolume", out float musicValue);
        MusicSlider.value = musicValue;

        audioMixer.GetFloat("SfxVolume", out float audioValue);
        AudioSlider.value = audioValue;

        AudioManager.StaticPlay("MainMenu");

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetAudioVolume(float volume)
    {
        if (volume == AudioSlider.minValue) volume = -80;
        audioMixer.SetFloat("SfxVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        if (volume == MusicSlider.minValue) volume = -80;
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetMasterVolume(float volume)
    {
        if (volume == MasterSlider.minValue) volume = -80;
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex + 1);
    }

    public void SetFullScreen(bool fullscreen)
    {
        this.fullscreen = fullscreen;
        Screen.fullScreen = fullscreen;

    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    public Slider musicSlider;
    public Slider soundSlider;
    private void Start()
    {
        audioMixer.GetFloat("Music",out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;
        audioMixer.GetFloat("Sound",out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        resolutions = resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        int count = 0;
        foreach (Resolution resolution in resolutions)
        {
            string option =  resolution.width.ToString() + "x" + resolution.height.ToString();
            options.Add(option);
            if(resolution.height == Screen.height && resolution.width == Screen.width )
            {
                currentResolutionIndex = count;
            }
            count++;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Music",volume);    
    }
    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("Sound",volume);    
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;   
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];   
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
}

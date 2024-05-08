using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (Resolution resolution in resolutions)
        {
            string option =  resolution.width.ToString() + "x" + resolution.height.ToString();
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);

    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);    
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;   
    }
}

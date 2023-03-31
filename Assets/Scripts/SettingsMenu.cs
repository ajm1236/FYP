using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resDrop;
    Resolution[] res;

    //way of setting inital screen resolution of game dependent on users screen

    private void Start()
    {
        res = Screen.resolutions;
        resDrop.ClearOptions();
        List<string> resStrings = new List<string>();
        int currRes = 0;

        // adding all the possible resoultions to a dropdown menu and adding the appropriate units
        for(int i = 0; i < res.Length; i++)
        {
            string option = res[i].width + "x" + res[i].height + "@" + res[i].refreshRate + "Hz"; 
            resStrings.Add(option);
            if(res[i].width == Screen.currentResolution.width && res[i].height == Screen.currentResolution.height)
            {
                currRes = i;
            }
        }
        resDrop.AddOptions(resStrings);
        resDrop.value = currRes;
        resDrop.RefreshShownValue();
    }
    // change volume using slide
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // change graphical qualities Unity provides
    public void SetGraphics(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
    
    //toggle windowed mode
    public void Fullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    //change screen resolution 
    public void SetResolution(int resIndex)
    {
        Resolution resoultion = res[resIndex];
        Screen.SetResolution(resoultion.width, resoultion.height, Screen.fullScreen);
    }
}

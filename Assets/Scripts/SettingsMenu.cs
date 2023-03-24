using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resDrop;
    Resolution[] res;

    private void Start()
    {
        res = Screen.resolutions;
        resDrop.ClearOptions();
        List<string> resStrings = new List<string>();
        int currRes = 0;
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
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetGraphics(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void Fullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void SetResolution(int resIndex)
    {
        Resolution resoultion = res[resIndex];
        Screen.SetResolution(resoultion.width, resoultion.height, Screen.fullScreen);
    }
}

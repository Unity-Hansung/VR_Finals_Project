using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer myMixer;
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBGMVolume();
            SetSFXVolume();
        }
    }

    public void SetBGMVolume()
    {
        float volume = Mathf.Log10(BGMSlider.value) * 20;
        myMixer.SetFloat("BGM", volume);
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
    }

    public void SetSFXVolume()
    {
        float volume = Mathf.Log10(SFXSlider.value) * 20;
        myMixer.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

    private void LoadVolume()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetBGMVolume();
        SetSFXVolume();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    AudioMixer myMixer;
    [SerializeField]
    Slider BGMSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBGMVolume();
        }
    }

    public void SetBGMVolume()
    {
        float volume = Mathf.Log10(BGMSlider.value) * 20;
        myMixer.SetFloat("BGM", volume);
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
    }

    private void LoadVolume()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");

        SetBGMVolume();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source")]
    [SerializeField]
    AudioSource BGMSource;
    [SerializeField]
    AudioSource SFXSource;

    [Header("-----Audio Clip")]
    public AudioClip Bgm;
    public AudioClip SFX;

    private void Start()
    {
        BGMSource.clip = Bgm;
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

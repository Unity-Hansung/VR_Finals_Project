using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("-----Audio Source")]
    [SerializeField]
    AudioSource BGMSource;
    [SerializeField]
    AudioSource SFXSource;

    [Header("-----Audio Clip")]
    public AudioClip Bgm;
    public AudioClip SFX;
    public AudioClip gameover;
    public AudioClip gameclear;
    public AudioClip basicShard;
    public AudioClip speedShard;
    public AudioClip colliShard;
    public AudioClip leverSwitch;
    public AudioClip spawnEnemy;

    private void Awake()
    {
        // Maintain AudioManager wherever
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        BGMSource.clip = Bgm;
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void ChangeBGM(AudioClip newClip, bool restartIfSame = false)
    {
        if (newClip == null)
            return;

        BGMSource.clip = newClip;
        BGMSource.Play();
    }
}

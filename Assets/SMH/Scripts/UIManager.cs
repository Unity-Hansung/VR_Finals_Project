using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // MainMenu Method
    public void StartBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
        SceneManager.LoadScene("TestScene");
    }
    public void OptionBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    AudioManager audioManager;
    CameraRotateController cameraController;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject optionUI;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        cameraController = Camera.main.GetComponent<CameraRotateController>();
    }

    // MainMenu Method
    public void StartBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
        SceneManager.LoadScene("STY_Scene");
    }
    public void OptionBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
        mainUI.SetActive(false);
        cameraController.SetTargetRotation(new Vector3(0f, -38f, 0f));
        optionUI.SetActive(true);
    }
    public void QuitBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
        Application.Quit();
    }

    // Option Method
    public void CloseOptionBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
        optionUI.SetActive(false);
        cameraController.SetDefaultRotation();
        mainUI.SetActive(true);
    }
}

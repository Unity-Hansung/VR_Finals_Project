using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] GameObject optionUI;

    bool isOnOption = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOnOption)
        {
            OnOptionUI();
        }
    }

    private void OnOptionUI()
    {
        audioManager.PlaySFX(audioManager.SFX);
        optionUI.SetActive(true);
        isOnOption = true;

        // 게임 멈추고 커서 활성화
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Btn Method
    public void CloseOptionBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
        optionUI.SetActive(false);
        isOnOption = false;

        // 다시 게임 재개
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
        SceneManager.LoadScene("STY_Scene");

        Time.timeScale = 1f;
    }

    public void ToMainBtn()
    {
        audioManager.PlaySFX(audioManager.SFX);
        SceneManager.LoadScene("Main");

        Time.timeScale = 1f;
    }
}

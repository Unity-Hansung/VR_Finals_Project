using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] GameObject optionUI;
    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject GameoverUI;
    [SerializeField] GameObject GameclearUI;

    bool isOnOption = false;

    [SerializeField] TextMeshProUGUI currentShardTxt;
    int currentShardCount;

    [SerializeField] TextMeshProUGUI currentTimeTxt;
    float currentTime;

    [SerializeField] TextMeshProUGUI recordTimeTxt;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        // 씬 시작시 배치된 샤드의 갯수 파악
        GameObject[] i = GameObject.FindGameObjectsWithTag("basicShard");
        currentShardCount = i.Length;
        currentShardTxt.text = currentShardCount.ToString();

        // 씬 시작시 현재 진행 시간 초기화
        currentTime = 0f;
    }

    private void Update()
    {
        SetCurrentTime();
        if (Input.GetKeyDown(KeyCode.Escape) && !isOnOption)
        {
            OnOptionUI();
        }
    }

    public void DecreaseShardCount()
    {// 현재 샤드 갯수 표시를 -1
        --currentShardCount;
        currentShardTxt.text = currentShardCount.ToString();
    }

    private void SetCurrentTime()
    {// 현재 진행 시간 표시를 업데이트
        currentTime += Time.deltaTime;

        // TimeSpan.FromSeconds(a) --> 초 단위값 숫자 시간 관리 객체로 변환한다. / Ex --> 78.27초 = 78
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(currentTime);

        // {0:D2} --> / D2 --> 숫자를 2자리 10진수로 출력한다. / 0 --> 인자값 인덱스 지정 / Ex --> 7 = 07
        // timeSpan.Minutes --> 분 단위값만 가져온다. / timeSpan.Seconds --> 초 단위값만 가져온다.
        currentTimeTxt.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds/10);
    }

    // 현재 진행 시간 반환
    public float GetCurrentTime()
    {
        return currentTime;
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

    // 게임오버 시 호출
    public IEnumerator OnGameoverUI()
    {
        audioManager.PlayGameoverBGM();
        //audioManager.PlaySFX(audioManager.gameover);
        GameUI.SetActive(false);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameoverUI.SetActive(true);
    }

    // 게임 클리어 시 호출
    public void OnGameclaerUI()
    {
        audioManager.PlayGameclearBGM();
        GameUI.SetActive(false);
        audioManager.PlaySFX(audioManager.gameclear);
        recordTimeTxt.text = currentTimeTxt.text;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameclearUI.SetActive(true);
    }
}
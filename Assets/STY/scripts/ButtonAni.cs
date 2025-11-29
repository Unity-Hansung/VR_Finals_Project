using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAni : MonoBehaviour
{
    private Animator animator;

    // 민혁의 수정 및 추가 부분
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        // 민혁의 수정 및 추가 부분
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayAin()
    {
        animator.SetTrigger("play");

        // 민혁의 수정 및 추가 부분
        audioManager.PlaySFX(audioManager.leverSwitch);
    }
   
}

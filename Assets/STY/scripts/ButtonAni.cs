using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAni : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayAin()
    {
        animator.SetTrigger("play");
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalGate : MonoBehaviour
{
    InGameUIManager igui;

    private void Start()
    {
        igui = GameObject.FindFirstObjectByType<InGameUIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            igui.OnGameclaerUI();
        }
    }
}

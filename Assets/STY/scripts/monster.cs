using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monster : MonoBehaviour
{
    [Header("Monster Camera")]
    [SerializeField] GameObject monCam;

    [Header("playerRender OFF")]
    [SerializeField] Renderer playerRenderer;
    [SerializeField] Renderer playerArm1;
    [SerializeField] Renderer playerArm2;

    Player player;
    NavMeshAgent agent;

    bool catchPlayer = true;

    // 민혁의 수정 및 추가 부분
    InGameUIManager ui;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();

        // 민혁의 수정 및 추가 부분
        ui = FindFirstObjectByType<InGameUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(catchPlayer)
            agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
               
            GameObject[] allMonsters = GameObject.FindGameObjectsWithTag("monster");

            Debug.Log("monster caught Player!");
            foreach(GameObject monster in allMonsters)
            {
                if(monster != this.gameObject)
                {
                    monster.SetActive(false);
                }
            }
            if(playerRenderer != null)
            {
                playerRenderer.enabled = false;
            }

            if(playerArm1 != null)
            {
                playerArm1.enabled = false;
            }

            if(playerArm2 != null)
            {
                playerArm2.enabled = false;
            }

            if(player != null)
            {
                player.enabled = false;
            }

            if(monCam != null)
            {
                monCam.SetActive(true);
            }
            catchPlayer = false;
            Debug.Log("몬스터가 플레이어를 잡았습니다");

            // 민혁의 수정 및 추가 부분
            StartCoroutine(ui.OnGameoverUI());
        }
    }
}

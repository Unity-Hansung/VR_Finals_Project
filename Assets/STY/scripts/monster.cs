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
    [SerializeField] GameObject playerRenderer;

    
    Player player;
    NavMeshAgent agent;

    bool catchPlayer = true;
    
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //몬스터 두 마리 중 먼저 플레이어와 trigger 닿은쪽만 활동 할 수 있도록 
        if(catchPlayer)
            agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("monster");

            foreach (GameObject monster in monsters)
            {
                if(monster != this.gameObject)
                {
                    monster.SetActive(false);
                }
            }
            
            //플레이어의 렌더링 부분 비활성화
            playerRenderer.SetActive(false);
            //플레이어 스크립트 비활성화
            player.enabled = false;
           //몬스터 시네머신 카메라 활성화
            monCam.SetActive(true);

            catchPlayer = false;

            Debug.Log("몬스터가 플레이어를 잡았습니다");

        }
    }
}

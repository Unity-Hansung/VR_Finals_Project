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
        //플레이어의 위치를 쫓아감 
        if(catchPlayer)
            agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            //괴물 두 마리중 한 마리가 플레이어와 먼저 충돌했을때 나머지 괴물을 안보이게
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("monster");

            foreach (GameObject monster in monsters)
            {
                if(monster != this.gameObject)
                {
                    monster.SetActive(false);
                }
            }
            
            //플레이어의 모습이 카메라에 안 잡히도록
            playerRenderer.SetActive(false);
           
            player.enabled = false;
           //몬스터의 시네머신 작동
            monCam.SetActive(true);

            catchPlayer = false;

            Debug.Log("���Ͱ� �÷��̾ ��ҽ��ϴ�");

            // ������ ���� �� �߰� �κ�
            StartCoroutine(ui.OnGameoverUI());
        }
    }
}

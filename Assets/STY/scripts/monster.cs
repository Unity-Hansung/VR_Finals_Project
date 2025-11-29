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
        //���� �� ���� �� ���� �÷��̾�� trigger �����ʸ� Ȱ�� �� �� �ֵ��� 
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
            
            //�÷��̾��� ������ �κ� ��Ȱ��ȭ
            playerRenderer.SetActive(false);
            //�÷��̾� ��ũ��Ʈ ��Ȱ��ȭ
            player.enabled = false;
           //���� �ó׸ӽ� ī�޶� Ȱ��ȭ
            monCam.SetActive(true);

            catchPlayer = false;

            Debug.Log("���Ͱ� �÷��̾ ��ҽ��ϴ�");

            // ������ ���� �� �߰� �κ�
            StartCoroutine(ui.OnGameoverUI());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    GameManager gm;
    Player player;

    [SerializeField] int scorePlus = 1;
    [SerializeField] float increaseRunning = 2f;
    [SerializeField] float runningCoolTime = 0.5f;
    [SerializeField] float ignoreMonsterTime = 3f;

    // 민혁의 수정 및 추가 부분
    InGameUIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>(); 
        player = FindFirstObjectByType<Player>();
        
        // 민혁의 수정 및 추가 부분
        ui=FindFirstObjectByType<InGameUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //한번씩 점수가 두 번 올라가는 현상 발생(11/18)
        if(other.CompareTag("basicShard"))
        {
            //플레이어의 점수가 1추가
            other.enabled = false;
            gm.AddScore(scorePlus);
            Destroy(other.gameObject);
            Debug.Log(gm.getScore());

            // 민혁의 수정 및 추가 부분
            ui.DecreaseShardCount();
        }
        //추가 기능 : 이속추가,충돌 무시 아이템 기능
        else if(other.CompareTag("speedShard"))
        {
            other.enabled = false;
            Destroy (other.gameObject);
            player.ApplySpeed(increaseRunning, runningCoolTime);
        }//원래 속도로 돌아오게끔
        else if(other.CompareTag("colliderShard"))
        {
            other.enabled = false;
            Destroy (other.gameObject);
            player.ApplySpeed(increaseRunning,runningCoolTime);
            player.StartCoroutine(player.throughMonster(ignoreMonsterTime));
        }
    }
}

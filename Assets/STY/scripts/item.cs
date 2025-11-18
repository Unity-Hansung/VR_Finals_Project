using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    GameManager gm;
    Player player;

    [SerializeField] int scorePlus = 1;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>(); 
        player = FindFirstObjectByType<Player>();
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
            gm.addScore(scorePlus);
            Destroy(other.gameObject);
            Debug.Log(gm.getScore());
        }
        //추가 기능 : 이속추가,충돌 무시 아이템 기능
        else if(other.CompareTag("speedShard"))
        {
            gm.addScore(scorePlus);
            Destroy (other.gameObject);
            player.setRunning(2.0f);
            Debug.Log(gm.getScore());
        }//원래 속도로 돌아오게끔
    }
}

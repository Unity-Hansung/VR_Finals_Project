using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score;

    [Header("Monster")]
    [SerializeField] GameObject monster1;
    [SerializeField] GameObject monster2;
    [Header("Gate")]
    [SerializeField] GameObject finalGate1;
    [SerializeField] GameObject finalGate2;
    [SerializeField] GameObject finalGate3;
    [SerializeField] GameObject finalGate4;

    //몬스터가 나오는 시간, 최종 관문이 열리는 점수
    [SerializeField] int finishScore;
    [SerializeField] float monster1ComingTime;
    [SerializeField] float monster2ComingTime;

    InGameUIManager um;
    AudioManager am;

    //버튼이 클릭됐음을 확인하는 변수
    bool btnCheck = true;

    int gateNumber;
    
    //몬스터의 중복 출현을 막는 변수
    bool isMonster1Spawned = false;
    bool isMonster2Spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        monster1.SetActive(false);
        monster2.SetActive(false);

        finalGate1.SetActive(false);
        finalGate2.SetActive(false);
        finalGate3.SetActive(false);
        finalGate4.SetActive(false);

        gateNumber= Random.Range(1, 5);

        um = FindFirstObjectByType<InGameUIManager>();
        am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
       //괴물1 등장
        if (um.GetCurrentTime() >= monster1ComingTime && !isMonster1Spawned)
        {
            monster1.SetActive(true);
            am.PlaySFX(am.spawnEnemy);
            isMonster1Spawned=true;
            Debug.Log("monster1 is coming!");
        }
        //괴물2 등장
        if(um.GetCurrentTime() >= monster2ComingTime && !isMonster2Spawned)
        {
          //등장 시간이 됐는데 버튼이 클릭 안 된 상태라면 괴물2 등장
          if(btnCheck) 
          {
                monster2.SetActive(true);
                am.PlaySFX(am.spawnEnemy);
                isMonster2Spawned =true;
                Debug.Log("monster2 is coming!");
          } 
        }
        //최종 점수 획득시 탈출로 등장
        if(um.GetCurrentShard() == 0)
        {
            //am.PlaySFX(am.openDoor);
            switch (gateNumber)
            {
                case 1:
                    finalGate1.SetActive(true);
                    break;
                case 2:
                    finalGate2.SetActive(true);
                    break;
                case 3:
                    finalGate3.SetActive(true);
                    break;
                case 4:
                    finalGate4.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public int getScore()
    {
        return score;
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    public void setCheck(bool check)
    {
        this.btnCheck = check;
    }
}

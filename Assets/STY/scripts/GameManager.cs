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
    [SerializeField] GameObject finalGate;
    [SerializeField] int monsterComingScore1;
    [SerializeField] int monsterComingScore2;
    [SerializeField] int finishScore;

    bool btnCheck = true;

    bool isMonster1Spawned = false;
    bool isMonster2Spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        monster1.SetActive(false);
        monster2.SetActive(false);
        finalGate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= monsterComingScore1 && !isMonster1Spawned)
        {
            monster1.SetActive(true);
            isMonster1Spawned=true;
            Debug.Log("monster1 is coming!");
        }
        if(score >= monsterComingScore2 && btnCheck && !isMonster2Spawned)
        {
            monster2.SetActive(true);
            isMonster2Spawned=true;
            Debug.Log("monster2 is coming!");
        }
        if(score >= finishScore)
        {
            finalGate.SetActive(true);
            Debug.Log("final gate open!");
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

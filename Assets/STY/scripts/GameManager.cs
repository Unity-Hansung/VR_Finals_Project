using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score;

    [Header("Monster")]
    [SerializeField] GameObject monster1;
    [SerializeField] GameObject monster2;
    [SerializeField] int monsterComingScore1;
    [SerializeField] int monsterComingScore2;

    bool btnCheck = true;
    // Start is called before the first frame update
    void Start()
    {
        monster1.SetActive(false);
        monster2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= monsterComingScore1)
        {
            monster1.SetActive(true);
            Debug.Log("monster1 is coming!");
        }
        if(score >= monsterComingScore2 && btnCheck)
        {
            monster2.SetActive(true);
            Debug.Log("monster2 is coming!");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Transform monsterSpawn1;
    [SerializeField] GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        monster.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 10)
        {
            monster.SetActive(true);
            Debug.Log("monster coming!");
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
}

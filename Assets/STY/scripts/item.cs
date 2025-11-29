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

    [Header("Particle System")]
    [SerializeField] ParticleSystem speedShard;
    [SerializeField] ParticleSystem colliderShard;

    // ������ ���� �� �߰� �κ�
    AudioManager audioManager;
    InGameUIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>(); 
        player = FindFirstObjectByType<Player>();
        
        // ������ ���� �� �߰� �κ�
        ui=FindFirstObjectByType<InGameUIManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //�ѹ��� ������ �� �� �ö󰡴� ���� �߻�(11/18)
        if(other.CompareTag("basicShard"))
        {
            //�÷��̾��� ������ 1�߰�
            other.enabled = false;
            gm.AddScore(scorePlus);
            Destroy(other.gameObject);
            Debug.Log(gm.getScore());

            // ������ ���� �� �߰� �κ�
            ui.DecreaseShardCount();
            audioManager.PlaySFX(audioManager.basicShard);
        }
        //�߰� ��� : �̼��߰�,�浹 ���� ������ ���
        else if(other.CompareTag("speedShard"))
        {
            other.enabled = false;
            Destroy (other.gameObject);
            player.ApplySpeed(increaseRunning, runningCoolTime);
            speedShard.Play();

            // ������ ���� �� �߰� �κ�
            audioManager.PlaySFX(audioManager.speedShard);
        }//���� �ӵ��� ���ƿ��Բ�
        else if(other.CompareTag("colliderShard"))
        {
            other.enabled = false;
            Destroy (other.gameObject);
            player.ApplySpeed(increaseRunning,runningCoolTime);
            player.StartCoroutine(player.throughMonster(ignoreMonsterTime));
            colliderShard.Play();

            // ������ ���� �� �߰� �κ�
            audioManager.PlaySFX(audioManager.colliShard);
        }
    }
}

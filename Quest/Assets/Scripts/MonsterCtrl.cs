using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public enum MonsterState { idle, trace, attack, die };
    public MonsterState monsterState = MonsterState.idle;
    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    private bool isDie = false;
    public float hp;

    void Start()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        nvAgent.destination = playerTr.position;

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }
    void Update()
    {
        nvAgent.destination = playerTr.position;
    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(playerTr.position, monsterTr.position);
            if (dist <= attackDist && !FindObjectOfType<GameManager>().isGameOver)
            {
                monsterState = MonsterState.attack;
            }
            else if (dist <= traceDist && !FindObjectOfType<GameManager>().isGameOver)
            { 
                monsterState = MonsterState.trace;
            }
            else
            {
                monsterState = MonsterState.idle;
            }
        }
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (monsterState)
            {
                case MonsterState.idle:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsTrace", false); 
                    break;
                case MonsterState.trace:
                    nvAgent.destination = playerTr.position; 
                    nvAgent.isStopped = false;
                    animator.SetBool("IsTrace", true);
                    animator.SetBool("IsAttack", false);
                    break;
                case MonsterState.attack:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsAttack", true);
                    break;
            }
            yield return null;
        }
    }

    public void GetDamage(float amounnt)
    {
        hp -= (int)(amounnt / 2.0f);
        animator.SetTrigger("IsHit");

        if (hp <= 0)
        {
            MonsterDie();
        }
    }

    void MonsterDie()
    {
        if (isDie)
        {
            StopAllCoroutines();
            isDie = true;
            monsterState = MonsterState.die;
            nvAgent.isStopped = true;
            animator.SetTrigger("IsDie");

            gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
            foreach (Collider coll in gameObject.GetComponentsInChildren<SphereCollider>())
            {
                coll.enabled = true;
            }
            FindObjectOfType<GameManager>().GetScored(2);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    private NavMeshAgent agent; // NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent 가져오기
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // 플레이어를 따라감
        }
    }
}

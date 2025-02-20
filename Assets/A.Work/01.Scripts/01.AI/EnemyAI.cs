using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // �÷��̾� ��ġ
    private NavMeshAgent agent; // NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent ��������
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // �÷��̾ ����
        }
    }
}

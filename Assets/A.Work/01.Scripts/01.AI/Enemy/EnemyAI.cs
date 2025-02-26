using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // �÷��̾� ��ġ
    private NavMeshAgent agent; // NavMeshAgent

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent ��������
        GameObject playerObj = GameObject.FindWithTag("MainCamera");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // �÷��̾ ����
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HpSystem hp = other.gameObject.GetComponent<HpSystem>();
            hp.TakeDamage(20f);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            HpSystem hp = gameObject.GetComponent<HpSystem>();
            hp.TakeDamage(30f);
            Destroy(other.gameObject);
            Debug.Log("�Ѿ� ����");
        }
    }

}

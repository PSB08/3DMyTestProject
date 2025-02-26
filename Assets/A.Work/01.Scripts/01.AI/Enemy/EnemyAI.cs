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
            StartCoroutine(Hit());
            HpSystem hp = gameObject.GetComponent<HpSystem>();
            hp.TakeDamage(50f);
            Destroy(other.gameObject);
            Debug.Log("�Ѿ� ����");
        }
    }

    private IEnumerator Hit()
    {
        MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        mesh.material.color = Color.white;
    }

}

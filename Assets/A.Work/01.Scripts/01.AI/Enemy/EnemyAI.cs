using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    private NavMeshAgent agent; // NavMeshAgent

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent 가져오기
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
            agent.SetDestination(player.position); // 플레이어를 따라감
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
            Debug.Log("총알 적중");
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

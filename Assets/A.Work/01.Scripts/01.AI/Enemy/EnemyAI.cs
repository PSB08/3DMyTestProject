using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public EnemySpawner spawner;
    private NavMeshAgent agent;
    private MeshRenderer mesh;
    private Color startColor;

    private void Awake()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        startColor = mesh.material.color;
    }

    private void Start()
    {
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
            agent.SetDestination(player.position);
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
            Debug.Log("ÃÑ¾Ë ÀûÁß");
        }
    }

    private IEnumerator Hit()
    {
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        mesh.material.color = startColor;
    }

    public void SpawnCountMinus()
    {
        spawner.currentSpawned--;
    }

}

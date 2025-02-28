using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public int attackDamage = 5;
    public float moveSpeed = 5f;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("(5)적 공격 받음 남은 체력: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("(8)적 사망!");
        Destroy(gameObject);
    }

    public void MoveToPlayer(Player player)
    {
        StartCoroutine(MoveToTarget(player.transform.position, () => {
            Attack(player);
            MoveBackToOriginalPosition();
        }));
    }

    private void MoveBackToOriginalPosition()
    {
        StartCoroutine(MoveToTarget(originalPosition, () => {
            GameManager.Instance.EndEnemyTurn();
        }));
    }

    private IEnumerator MoveToTarget(Vector3 target, System.Action onComplete)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
        onComplete?.Invoke();
    }

    private void Attack(Player player)
    {
        Debug.Log("(7)적 플레이어 공격함!");
        player.TakeDamage(attackDamage);
    }

}

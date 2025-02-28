using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attackDamage = 10;
    public int health = 50;
    public float moveSpeed = 5f;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void Attack(Enemy enemy)
    {
        Debug.Log("(3)플레이어가 공격함");
        enemy.TakeDamage(attackDamage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("(4)플레이어 공격 받음 남은 체력: " + health);
    }

    public void MoveToEnemy(Enemy enemy)
    {
        StartCoroutine(MoveToTarget(enemy.transform.position, () => {
            Attack(enemy);
            MoveBackToOriginalPosition();
        }));
    }

    private void MoveBackToOriginalPosition()
    {
        StartCoroutine(MoveToTarget(originalPosition, () => {
            GameManager.Instance.EndPlayerTurn();
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

}

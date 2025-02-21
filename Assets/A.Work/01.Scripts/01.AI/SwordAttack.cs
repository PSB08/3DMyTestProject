using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator; // 애니메이터
    public float attackRange = 1.5f; // 공격 범위
    public int attackDamage = 20; // 공격력
    public LayerMask enemyLayer; // 공격할 대상 (적)

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭 감지
        {
            Debug.Log(1);
            Attack();
        }
    }

    private void Attack()
    {
        // 애니메이션 실행
        animator.SetTrigger("Attack");

        // 공격 범위 내의 적을 감지
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("적 적중: " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // 공격 범위 시각화
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

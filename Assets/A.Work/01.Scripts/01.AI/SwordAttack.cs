using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 1.5f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;
    public int attackComboMax = 2; // 최대 콤보 수 설정 가능

    private int attackCombo = 0;
    private float lastAttackTime;
    public float comboResetTime = 1.0f; // 콤보 초기화 시간
    private bool isAttacking = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
        }

        // 일정 시간 내 추가 입력 없으면 콤보 초기화
        if (Time.time - lastAttackTime > comboResetTime)
        {
            attackCombo = 0;
            isAttacking = false;
            animator.SetTrigger("Idle");
        }
    }

    private void Attack()
    {
        isAttacking = true;
        attackCombo = (attackCombo % attackComboMax) + 1;
        lastAttackTime = Time.time;

        animator.SetTrigger("Attack" + attackCombo);
    }

    // 애니메이션 이벤트로 호출할 메서드 (애니메이션 끝날 때 실행)
    public void OnAttackAnimationEnd()
    {
        isAttacking = false;
    }

    private void DealDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("적 적중: " + enemy.name);
            Destroy(enemy.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

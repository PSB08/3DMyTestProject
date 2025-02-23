using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 1.5f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;
    public int attackComboMax = 2; // �ִ� �޺� �� ���� ����

    private int attackCombo = 0;
    private float lastAttackTime;
    public float comboResetTime = 1.0f; // �޺� �ʱ�ȭ �ð�
    private bool isAttacking = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
        }

        // ���� �ð� �� �߰� �Է� ������ �޺� �ʱ�ȭ
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

    // �ִϸ��̼� �̺�Ʈ�� ȣ���� �޼��� (�ִϸ��̼� ���� �� ����)
    public void OnAttackAnimationEnd()
    {
        isAttacking = false;
    }

    private void DealDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("�� ����: " + enemy.name);
            Destroy(enemy.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

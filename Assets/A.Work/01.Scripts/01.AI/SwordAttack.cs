using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator; // �ִϸ�����
    public float attackRange = 1.5f; // ���� ����
    public int attackDamage = 20; // ���ݷ�
    public LayerMask enemyLayer; // ������ ��� (��)

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ�� ����
        {
            Debug.Log(1);
            Attack();
        }
    }

    private void Attack()
    {
        // �ִϸ��̼� ����
        animator.SetTrigger("Attack");

        // ���� ���� ���� ���� ����
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("�� ����: " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // ���� ���� �ð�ȭ
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

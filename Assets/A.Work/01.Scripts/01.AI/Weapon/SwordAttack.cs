using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 1.5f;
    public LayerMask enemyLayer;
    public int attackComboMax = 2;

    private int attackCombo = 0;
    private float lastAttackTime;
    public float comboResetTime = 1.0f;
    private bool isAttacking = false;
    private bool isHoldingAttack = false;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isHoldingAttack = true;
            if (!isAttacking)
            {
                Attack();
            }
        }
        else
        {
            isHoldingAttack = false;
        }

        if (Time.time - lastAttackTime > comboResetTime)
        {
            attackCombo = 0;
            isAttacking = false;
            animator.SetTrigger("Idle");
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Shield");
        }

    }

    private void Attack()
    {
        isAttacking = true;
        attackCombo = (attackCombo % attackComboMax) + 1;
        lastAttackTime = Time.time;

        animator.SetTrigger("Attack" + attackCombo);
    }

    public void OnAttackAnimationEnd()
    {
        isAttacking = false;
        if (isHoldingAttack)
        {
            Attack();
        }
    }

    private void DealDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Àû ÀûÁß: " + enemy.name);
            HpSystem enemyHp = enemy.GetComponent<HpSystem>();
            enemyHp.TakeDamage(20f);
        }
    }
    void OnDisable()
    {
        Quaternion rot = Quaternion.Euler(0, 90, 16);
        transform.localPosition = new Vector3(1.3f, 0, 2);
        transform.localRotation = rot;
    }
    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }*/

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [Header("Component")]
    public Animator animator;
    public HpSystem hpSystem;
    [Header("Value")]
    public float attackRange = 1.5f;
    public LayerMask enemyLayer;
    public int attackComboMax = 2;
    public float comboResetTime = 1.0f;

    private int attackCombo = 0;
    private float lastAttackTime;
    private bool isAttacking = false;
    private bool isHoldingAttack = false;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("Shield", true);
        }
        else
        {
            animator.SetBool("Shield", false);
        }

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
            Debug.Log("적 적중: " + enemy.name);
            HpSystem enemyHp = enemy.GetComponent<HpSystem>();
            enemyHp.TakeDamage(20f);
        }
    }

    private void OnDisable()
    {
        Quaternion rot = Quaternion.Euler(0, 90, 16);
        transform.localPosition = new Vector3(1.3f, 0, 2);
        transform.localRotation = rot;
    }
   
    public void ShieldHeal(float x)
    {
        hpSystem.Heal(x);
    }

}

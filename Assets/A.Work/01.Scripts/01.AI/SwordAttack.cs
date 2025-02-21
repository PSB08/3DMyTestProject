using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 1.5f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(1);
            Attack();
        }
        animator.SetTrigger("Idle");
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Рћ РћСп: " + enemy.name);
            Destroy(enemy.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int defense;
    public int speed; // �� ������ �����ϴ� �ӵ�
    public bool isPlayerTeam; // true: �÷��̾� ��, false: �� ��
    public bool hasTakenTurn; // �̹� ���忡 ���� ����ߴ��� ����

    // ĳ���� �ʱ�ȭ
    public virtual void Initialize(string name, int health, int atk, int def, int spd, bool isPlayer)
    {
        characterName = name;
        maxHealth = health;
        currentHealth = health;
        attack = atk;
        defense = def;
        speed = spd;
        isPlayerTeam = isPlayer;
    }

    // ������ �ޱ�
    public virtual void TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(1, damage - defense);
        currentHealth = Mathf.Max(0, currentHealth - actualDamage);

        // ������ �ؽ�Ʈ ǥ�� (UI �Ŵ����� ���� ����)
        //CombatUIManager.Instance.ShowDamageText(transform.position, actualDamage);

        // ü���� 0�� �Ǹ� ��� ó��
        if (currentHealth <= 0)
            Die();
    }

    // ��� ó��
    public virtual void Die()
    {

        // ���� �Ŵ������� ��� �˸�
        CombatManager.Instance.CharacterDied(this);

        // 2�� �� ������Ʈ ��Ȱ��ȭ
        StartCoroutine(DeactivateAfterDelay(2f));
    }

    IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    // ������ �̵��ϰ� �����ϴ� �ڷ�ƾ
    public IEnumerator MoveToTargetAndAttack(Character target)
    {
        // ���� ��ġ ����
        Vector3 originalPosition = transform.position;

        // Ÿ���� ���� ȸ��
        transform.LookAt(target.transform);

        // Ÿ�� ������ �̵� (�ణ ���� ����)
        Vector3 targetPosition = target.transform.position - (target.transform.position - transform.position).normalized * 1.5f;
        float moveSpeed = 5f;

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // �ִϸ��̼� Ÿ�ֿ̹� ���߾� ������ ���� (�� 0.5�� ��)
        yield return new WaitForSeconds(0.5f);

        // ������ ����
        target.TakeDamage(attack);

        // ��� ���
        yield return new WaitForSeconds(1f);

        // ���� ��ġ�� ���ư���
        while (Vector3.Distance(transform.position, originalPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // �� ���� ó��
        CombatManager.Instance.EndTurn();
    }
}

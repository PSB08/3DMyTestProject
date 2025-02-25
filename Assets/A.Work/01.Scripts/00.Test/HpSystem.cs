using System;
using UnityEngine;

public class HpSystem : MonoBehaviour
{
    public static HpSystem Instance { get; private set; }

    [Header("ü�� ����")]
    public float maxHealth = 100f;
    public float currentHealth;

    public event Action<float, float> OnHealthChanged;
    public event Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    // �����ڰ� ��󿡰� �������� �ִ� ���
    public void Damage(GameObject target, float amount)
    {
        HpSystem targetHealth = target.GetComponent<HpSystem>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(amount);
        }
    }

    // �������� �޴� �޼���
    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) return; // �̹� �׾����� ���� X

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ü�� 0~�ִ밪 ����
        OnHealthChanged?.Invoke(currentHealth, maxHealth); // ü�� ���� �̺�Ʈ ����

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ü���� ȸ���ϴ� �޼���
    public void Heal(float amount)
    {
        if (currentHealth <= 0) return; // ���� ���¿����� ȸ�� �Ұ�

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // ��� ó�� �޼���
    private void Die()
    {
        Debug.Log(gameObject.name + "��(��) ����߽��ϴ�.");
        OnDeath?.Invoke(); // ��� �̺�Ʈ ����
        Destroy(gameObject);
    }

    // ���� ü�� ��ȯ
    public float GetHealth()
    {
        return currentHealth;
    }

}

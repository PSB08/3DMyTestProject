using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HpSystem : MonoBehaviour
{
    public static HpSystem Instance { get; private set; }

    [Header("ü�� ����")]
    public float maxHealth = 100f;
    public float currentHealth;

    public event Action<float, float> OnHealthChanged;
    public UnityEvent OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
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
        if (gameObject.name.Contains("Player"))
        {
            SceneManager.LoadScene(0);
        }
        if (gameObject.name.Contains("Enemy"))
        {
            Destroy(gameObject);
        }
        OnDeath?.Invoke(); // ��� �̺�Ʈ ����
    }

    // ���� ü�� ��ȯ
    public float GetHealth()
    {
        return currentHealth;
    }

}

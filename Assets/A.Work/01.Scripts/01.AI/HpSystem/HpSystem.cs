using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HpSystem : MonoBehaviour
{
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
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (currentHealth <= 0) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

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
        OnDeath?.Invoke();
    }

    public float GetHealth()
    {
        return currentHealth;
    }

}

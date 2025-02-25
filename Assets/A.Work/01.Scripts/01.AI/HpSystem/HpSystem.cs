using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpSystem : MonoBehaviour
{
    public static HpSystem Instance { get; private set; }

    [Header("체력 설정")]
    public float maxHealth = 100f;
    public float currentHealth;

    public event Action<float, float> OnHealthChanged;
    public event Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    // 데미지를 받는 메서드
    public void TakeDamage(float amount)
    {
        if (currentHealth <= 0) return; // 이미 죽었으면 실행 X

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 체력 0~최대값 유지
        OnHealthChanged?.Invoke(currentHealth, maxHealth); // 체력 변경 이벤트 실행

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 체력을 회복하는 메서드
    public void Heal(float amount)
    {
        if (currentHealth <= 0) return; // 죽은 상태에서는 회복 불가

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // 사망 처리 메서드
    private void Die()
    {
        if (gameObject.name == "Player")
        {
            SceneManager.LoadScene(0);
        }
        if (gameObject.name.Contains("Enemy"))
        {
            Debug.Log(gameObject.name + "이(가) 사망했습니다.");
            Destroy(gameObject);
        }
        OnDeath?.Invoke(); // 사망 이벤트 실행
    }

    // 현재 체력 반환
    public float GetHealth()
    {
        return currentHealth;
    }

}

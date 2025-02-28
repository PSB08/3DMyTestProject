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
    public int speed; // 턴 순서를 결정하는 속도
    public bool isPlayerTeam; // true: 플레이어 팀, false: 적 팀
    public bool hasTakenTurn; // 이번 라운드에 턴을 사용했는지 여부

    // 캐릭터 초기화
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

    // 데미지 받기
    public virtual void TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(1, damage - defense);
        currentHealth = Mathf.Max(0, currentHealth - actualDamage);

        // 데미지 텍스트 표시 (UI 매니저를 통해 구현)
        //CombatUIManager.Instance.ShowDamageText(transform.position, actualDamage);

        // 체력이 0이 되면 사망 처리
        if (currentHealth <= 0)
            Die();
    }

    // 사망 처리
    public virtual void Die()
    {

        // 전투 매니저에게 사망 알림
        CombatManager.Instance.CharacterDied(this);

        // 2초 후 오브젝트 비활성화
        StartCoroutine(DeactivateAfterDelay(2f));
    }

    IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    // 적에게 이동하고 공격하는 코루틴
    public IEnumerator MoveToTargetAndAttack(Character target)
    {
        // 원래 위치 저장
        Vector3 originalPosition = transform.position;

        // 타겟을 향해 회전
        transform.LookAt(target.transform);

        // 타겟 앞으로 이동 (약간 간격 유지)
        Vector3 targetPosition = target.transform.position - (target.transform.position - transform.position).normalized * 1.5f;
        float moveSpeed = 5f;

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // 애니메이션 타이밍에 맞추어 데미지 적용 (약 0.5초 후)
        yield return new WaitForSeconds(0.5f);

        // 데미지 적용
        target.TakeDamage(attack);

        // 잠시 대기
        yield return new WaitForSeconds(1f);

        // 원래 위치로 돌아가기
        while (Vector3.Distance(transform.position, originalPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // 턴 종료 처리
        CombatManager.Instance.EndTurn();
    }
}

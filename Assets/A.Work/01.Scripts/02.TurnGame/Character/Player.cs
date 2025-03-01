using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string CharacterName; // 캐릭터 이름
    public int Health = 100;      // 기본 체력
    public int AttackPower = 20;  // 기본 공격력
    public float Speed;            // 속도
    public float AttackMoveSpeed = 3f; // 공격 시 이동 속도
    private Vector3 originalPosition; // 원래 위치 저장

    private void Start()
    {
        originalPosition = transform.position; // 시작할 때 원래 위치 저장
    }

    private void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }

    public void Attack(Enemy target)
    {
        if (target != null && target.Health > 0)
        {
            // 공격할 위치로 이동
            MoveTo(target.transform.position, () =>
            {
                target.Health -= AttackPower; // 공격력만큼 체력 감소
                Debug.Log($"{CharacterName}가 {target.CharacterName}를 공격했습니다! (남은 체력: {target.Health})");
                // 원래 위치로 돌아가기
                MoveTo(originalPosition, null);
            }, AttackMoveSpeed); // 공격 시 속도 사용
        }
    }

    public void MoveTo(Vector3 targetPosition, System.Action onComplete = null, float moveSpeed = 5f)
    {
        StartCoroutine(MoveCoroutine(targetPosition, onComplete, moveSpeed));
    }

    private IEnumerator MoveCoroutine(Vector3 targetPosition, System.Action onComplete, float moveSpeed)
    {
        float journeyLength = Vector3.Distance(transform.position, targetPosition);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, targetPosition, fractionOfJourney);
            yield return null;
        }

        transform.position = targetPosition; // 정확한 위치 설정
        onComplete?.Invoke(); // 이동 완료 후 콜백 호출
    }

}

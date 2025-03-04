using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string CharacterName;
    public int Health = 100;    
    public int AttackPower = 20;
    public float Speed;
    public float AttackMoveSpeed = 3f;
    private Vector3 originalPosition;
    public PlayerHealthText healthText;

    private void Start()
    {
        healthText.player = this;
        originalPosition = transform.position;
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
            MoveTo(target.transform.position, () =>
            {
                target.Health -= AttackPower;
                Debug.Log($"{CharacterName}가 {target.CharacterName}를 공격했습니다! (남은 체력: {target.Health})");
                MoveTo(originalPosition, null);
            }, AttackMoveSpeed);
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

        transform.position = targetPosition;
        onComplete?.Invoke();
    }

}

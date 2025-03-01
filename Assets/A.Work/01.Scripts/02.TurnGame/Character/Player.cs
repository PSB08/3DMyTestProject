using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string CharacterName; // ĳ���� �̸�
    public int Health = 100;      // �⺻ ü��
    public int AttackPower = 20;  // �⺻ ���ݷ�
    public float Speed;            // �ӵ�
    public float AttackMoveSpeed = 3f; // ���� �� �̵� �ӵ�
    private Vector3 originalPosition; // ���� ��ġ ����

    private void Start()
    {
        originalPosition = transform.position; // ������ �� ���� ��ġ ����
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
            // ������ ��ġ�� �̵�
            MoveTo(target.transform.position, () =>
            {
                target.Health -= AttackPower; // ���ݷ¸�ŭ ü�� ����
                Debug.Log($"{CharacterName}�� {target.CharacterName}�� �����߽��ϴ�! (���� ü��: {target.Health})");
                // ���� ��ġ�� ���ư���
                MoveTo(originalPosition, null);
            }, AttackMoveSpeed); // ���� �� �ӵ� ���
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

        transform.position = targetPosition; // ��Ȯ�� ��ġ ����
        onComplete?.Invoke(); // �̵� �Ϸ� �� �ݹ� ȣ��
    }

}

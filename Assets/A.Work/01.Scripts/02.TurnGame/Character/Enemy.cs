using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string CharacterName;
    public int Health = 100;
    public int AttackPower = 15;
    public float Speed;
    public float AttackMoveSpeed = 3f;
    public EnemyHealthText healthText;
    public Material nameMat;
    public Transform[] playerTransforms;
    private Vector3 originalPosition;
    public CamChange camChange;

    private void Start()
    {
        healthText.enemy = this;
        originalPosition = transform.position;
        camChange = GameObject.FindGameObjectWithTag("Manager").GetComponent<CamChange>();
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        playerTransforms = new Transform[playerObjects.Length];

        for (int i = 0; i < playerObjects.Length; i++)
        {
            playerTransforms[i] = playerObjects[i].transform;
        }
    }

    private void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }

    public void AttackRandomPlayer()
    {
        if (playerTransforms.Length > 0)
        {
            int randomIndex = Random.Range(0, playerTransforms.Length);
            Player target = playerTransforms[randomIndex].GetComponent<Player>();
            camChange.CameraSetting(randomIndex + 1);
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

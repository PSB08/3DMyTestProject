using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string CharacterName; // 캐릭터 이름
    public int Health = 100;      // 기본 체력
    public int AttackPower = 15;  // 기본 공격력
    public float Speed;            // 속도
    public Transform[] playerTransforms; // 플레이어 위치 배열

    public void Initialize(Transform[] playerTransforms)
    {
        this.playerTransforms = playerTransforms; // 플레이어 Transform 배열 초기화
    }

    public void AttackRandomPlayer()
    {
        if (playerTransforms.Length > 0)
        {
            // 랜덤으로 플레이어 선택
            int randomIndex = Random.Range(0, playerTransforms.Length);
            Player target = playerTransforms[randomIndex].GetComponent<Player>();

            if (target != null && target.Health > 0)
            {
                target.Health -= AttackPower; // 공격력만큼 체력 감소
                Debug.Log($"{CharacterName}가 {target.CharacterName}를 공격했습니다! (남은 체력: {target.Health})");
            }
        }
    }

}

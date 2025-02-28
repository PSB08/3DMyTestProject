using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string CharacterName; // 캐릭터 이름
    public int Health = 100;      // 기본 체력
    public int AttackPower = 20;  // 기본 공격력
    public float Speed;            // 속도

    public void Attack(Enemy target)
    {
        if (target != null && target.Health > 0)
        {
            target.Health -= AttackPower; // 공격력만큼 체력 감소
            Debug.Log($"{CharacterName}가 {target.CharacterName}를 공격했습니다! (남은 체력: {target.Health})");
        }
    }

}

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string CharacterName; // ĳ���� �̸�
    public int Health = 100;      // �⺻ ü��
    public int AttackPower = 20;  // �⺻ ���ݷ�
    public float Speed;            // �ӵ�

    public void Attack(Enemy target)
    {
        if (target != null && target.Health > 0)
        {
            target.Health -= AttackPower; // ���ݷ¸�ŭ ü�� ����
            Debug.Log($"{CharacterName}�� {target.CharacterName}�� �����߽��ϴ�! (���� ü��: {target.Health})");
        }
    }

}

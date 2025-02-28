using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string CharacterName; // ĳ���� �̸�
    public int Health = 100;      // �⺻ ü��
    public int AttackPower = 15;  // �⺻ ���ݷ�
    public float Speed;            // �ӵ�
    public Transform[] playerTransforms; // �÷��̾� ��ġ �迭

    public void Initialize(Transform[] playerTransforms)
    {
        this.playerTransforms = playerTransforms; // �÷��̾� Transform �迭 �ʱ�ȭ
    }

    public void AttackRandomPlayer()
    {
        if (playerTransforms.Length > 0)
        {
            // �������� �÷��̾� ����
            int randomIndex = Random.Range(0, playerTransforms.Length);
            Player target = playerTransforms[randomIndex].GetComponent<Player>();

            if (target != null && target.Health > 0)
            {
                target.Health -= AttackPower; // ���ݷ¸�ŭ ü�� ����
                Debug.Log($"{CharacterName}�� {target.CharacterName}�� �����߽��ϴ�! (���� ü��: {target.Health})");
            }
        }
    }

}

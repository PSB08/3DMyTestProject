using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] playerCharacterPrefabs;

    // �� ĳ���� ������
    public GameObject[] enemyCharacterPrefabs;

    // ���� ��ġ (�÷��̾� ��)
    public Transform[] playerPositions;

    // ���� ��ġ (�� ��)
    public Transform[] enemyPositions;

    void Start()
    {
        // ���� �ʱ�ȭ
        InitializeCombat();
    }

    // ���� �ʱ�ȭ
    void InitializeCombat()
    {
        // �÷��̾� �� ���� (4��)
        List<Character> playerTeam = new List<Character>();
        for (int i = 0; i < 4; i++)
        {
            GameObject playerObj = Instantiate(playerCharacterPrefabs[i % playerCharacterPrefabs.Length], playerPositions[i].position, playerPositions[i].rotation);
            Character playerChar = playerObj.GetComponent<Character>();

            // ĳ���� �ʱ�ȭ (�̸�, ü��, ���ݷ�, ����, �ӵ�, �÷��̾� ����)
            playerChar.Initialize("Player " + (i + 1), 100, 20, 10, Random.Range(80, 100), true);

            playerTeam.Add(playerChar);
        }

        // �� �� ���� (�����ϰ� 1~5��)
        int enemyCount = Random.Range(3, 6); // 3~5��
        List<Character> enemyTeam = new List<Character>();
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemyObj = Instantiate(enemyCharacterPrefabs[i % enemyCharacterPrefabs.Length], enemyPositions[i].position, enemyPositions[i].rotation);
            Character enemyChar = enemyObj.GetComponent<Character>();

            // ĳ���� �ʱ�ȭ (�̸�, ü��, ���ݷ�, ����, �ӵ�, �÷��̾� ����)
            enemyChar.Initialize("Enemy " + (i + 1), 80, 15, 8, Random.Range(60, 90), false);

            enemyTeam.Add(enemyChar);
        }

        // ���� ����
        CombatManager.Instance.StartCombat(playerTeam, enemyTeam);
    }
}

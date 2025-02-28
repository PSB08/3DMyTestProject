using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] playerCharacterPrefabs;

    // 적 캐릭터 프리팹
    public GameObject[] enemyCharacterPrefabs;

    // 전투 위치 (플레이어 팀)
    public Transform[] playerPositions;

    // 전투 위치 (적 팀)
    public Transform[] enemyPositions;

    void Start()
    {
        // 전투 초기화
        InitializeCombat();
    }

    // 전투 초기화
    void InitializeCombat()
    {
        // 플레이어 팀 생성 (4명)
        List<Character> playerTeam = new List<Character>();
        for (int i = 0; i < 4; i++)
        {
            GameObject playerObj = Instantiate(playerCharacterPrefabs[i % playerCharacterPrefabs.Length], playerPositions[i].position, playerPositions[i].rotation);
            Character playerChar = playerObj.GetComponent<Character>();

            // 캐릭터 초기화 (이름, 체력, 공격력, 방어력, 속도, 플레이어 여부)
            playerChar.Initialize("Player " + (i + 1), 100, 20, 10, Random.Range(80, 100), true);

            playerTeam.Add(playerChar);
        }

        // 적 팀 생성 (랜덤하게 1~5명)
        int enemyCount = Random.Range(3, 6); // 3~5명
        List<Character> enemyTeam = new List<Character>();
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemyObj = Instantiate(enemyCharacterPrefabs[i % enemyCharacterPrefabs.Length], enemyPositions[i].position, enemyPositions[i].rotation);
            Character enemyChar = enemyObj.GetComponent<Character>();

            // 캐릭터 초기화 (이름, 체력, 공격력, 방어력, 속도, 플레이어 여부)
            enemyChar.Initialize("Enemy " + (i + 1), 80, 15, 8, Random.Range(60, 90), false);

            enemyTeam.Add(enemyChar);
        }

        // 전투 시작
        CombatManager.Instance.StartCombat(playerTeam, enemyTeam);
    }
}

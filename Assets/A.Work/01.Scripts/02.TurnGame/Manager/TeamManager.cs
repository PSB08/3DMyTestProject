using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public GameObject[] playerPrefabs; // 플레이어 프리팹 배열
    public GameObject[] enemyPrefabs;  // 적 프리팹 배열
    public List<Player> playerTeam = new List<Player>();
    public List<Enemy> enemyTeam = new List<Enemy>();

    // 플레이어와 적의 위치 Transform 배열
    public Transform[] playerTransforms;
    public Transform[] enemyTransforms;

    public void InitializeTeams()
    {
        // 플레이어 소환
        for (int i = 0; i < playerTransforms.Length; i++)
        {
            GameObject playerObject = Instantiate(playerPrefabs[i], 
                playerTransforms[i].position, playerTransforms[i].rotation);
            Player player = playerObject.GetComponent<Player>();
            playerTeam.Add(player);
        }

        // 적 소환
        for (int j = 0; j < enemyTransforms.Length; j++)
        {
            GameObject enemyObject = Instantiate(enemyPrefabs[j], 
                enemyTransforms[j].position, enemyTransforms[j].rotation);
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.Initialize(playerTransforms); // 플레이어 Transform 배열 전달
            enemyTeam.Add(enemy);
        }
    }

}

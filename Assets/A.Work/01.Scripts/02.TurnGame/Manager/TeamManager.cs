using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public GameObject[] playerPrefabs; // �÷��̾� ������ �迭
    public GameObject[] enemyPrefabs;  // �� ������ �迭
    public List<Player> playerTeam = new List<Player>();
    public List<Enemy> enemyTeam = new List<Enemy>();

    // �÷��̾�� ���� ��ġ Transform �迭
    public Transform[] playerTransforms;
    public Transform[] enemyTransforms;

    public void InitializeTeams()
    {
        // �÷��̾� ��ȯ
        for (int i = 0; i < playerTransforms.Length; i++)
        {
            GameObject playerObject = Instantiate(playerPrefabs[i], 
                playerTransforms[i].position, playerTransforms[i].rotation);
            Player player = playerObject.GetComponent<Player>();
            playerTeam.Add(player);
        }

        // �� ��ȯ
        for (int j = 0; j < enemyTransforms.Length; j++)
        {
            GameObject enemyObject = Instantiate(enemyPrefabs[j], 
                enemyTransforms[j].position, enemyTransforms[j].rotation);
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.Initialize(playerTransforms); // �÷��̾� Transform �迭 ����
            enemyTeam.Add(enemy);
        }
    }

}

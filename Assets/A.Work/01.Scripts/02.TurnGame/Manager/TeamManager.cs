using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs; 
    public List<Player> playerTeam = new List<Player>();
    public List<Enemy> enemyTeam = new List<Enemy>();

    public Transform[] playerTransforms;
    public Transform[] enemyTransforms;

    public TurnManager turnManager;

    private void Update()
    {
        CheckTeams();
    }

    public void InitializeTeams()
    {
        for (int j = 0; j < enemyTransforms.Length; j++)
        {
            int randomEnemy = Random.Range(0, enemyTransforms.Length);
            GameObject enemyObject = Instantiate(enemyPrefabs[randomEnemy],
                enemyTransforms[j].position, enemyTransforms[j].rotation);
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemyTeam.Add(enemy);
        }

        for (int i = 0; i < playerTransforms.Length; i++)
        {
            GameObject playerObject = Instantiate(playerPrefabs[i], 
                playerTransforms[i].position, playerTransforms[i].rotation);
            Player player = playerObject.GetComponent<Player>();
            playerTeam.Add(player);
        }
    }

    private void CheckTeams()
    {
        for (int i = playerTeam.Count - 1; i >= 0; i--)
        {
            if (playerTeam[i].Health <= 0)
            {
                turnManager.turnOrder.Remove(playerTeam[i]);
                playerTeam.RemoveAt(i);
            }
        }

        for (int i = enemyTeam.Count - 1; i >= 0; i--)
        {
            if (enemyTeam[i].Health <= 0)
            {
                turnManager.turnOrder.Remove(enemyTeam[i]);
                enemyTeam.RemoveAt(i);
            }
        }
    }


}

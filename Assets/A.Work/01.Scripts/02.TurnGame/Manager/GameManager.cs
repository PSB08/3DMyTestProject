using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TeamManager teamManager;
    public TurnManager turnManager;

    private void Start()
    {
        teamManager.InitializeTeams();
        turnManager.SetupTurnOrder(teamManager.playerTeam, teamManager.enemyTeam);
        turnManager.NextTurn(); // ù ���� �����մϴ�.

        // �� �ϸ��� ���� �����ϵ��� ���� (��: 2�ʸ���)
        InvokeRepeating("EnemyAttack", 1f, 2f);
    }

    public void PlayerAttack(Enemy target)
    {
        var currentCharacter = turnManager.turnOrder[turnManager.currentTurnIndex];

        if (currentCharacter is Player currentPlayer)
        {
            currentPlayer.Attack(target);
            turnManager.NextTurn(); // ���� �� �� �ѱ��
        }
    }

    private void EnemyAttack()
    {
        foreach (var enemy in teamManager.enemyTeam)
        {
            if (enemy != null)
            {
                enemy.AttackRandomPlayer();
            }
        }
    }

    private void Update()
    {
        var currentCharacter = turnManager.turnOrder[turnManager.currentTurnIndex];

        if (currentCharacter is Player currentPlayer) // ���� ���� �÷��̾��� ��
        {
            if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Enemy clickedEnemy = hit.transform.GetComponent<Enemy>();
                    if (clickedEnemy != null && clickedEnemy.Health > 0)
                    {
                        PlayerAttack(clickedEnemy);
                    }
                }
            }
        }
    }

}

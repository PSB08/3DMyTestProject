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
        turnManager.NextTurn(); // 첫 턴을 시작합니다.

        // 매 턴마다 적이 공격하도록 설정 (예: 2초마다)
        InvokeRepeating("EnemyAttack", 1f, 2f);
    }

    public void PlayerAttack(Enemy target)
    {
        var currentCharacter = turnManager.turnOrder[turnManager.currentTurnIndex];

        if (currentCharacter is Player currentPlayer)
        {
            currentPlayer.Attack(target);
            turnManager.NextTurn(); // 공격 후 턴 넘기기
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

        if (currentCharacter is Player currentPlayer) // 현재 턴이 플레이어일 때
        {
            if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
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

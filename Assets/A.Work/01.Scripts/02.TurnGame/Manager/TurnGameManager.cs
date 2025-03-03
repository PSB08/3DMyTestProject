using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGameManager : MonoBehaviour
{
    public TeamManager teamManager;
    public TurnManager turnManager;

    private void Start()
    {
        teamManager.InitializeTeams();
        turnManager.SetupTurnOrder(teamManager.playerTeam, teamManager.enemyTeam);
        StartCoroutine(turnManager.NextTime());
    }

    public void PlayerAttack(Enemy target)
    {
        var currentCharacter = turnManager.turnOrder[turnManager.currentTurnIndex];

        if (currentCharacter is Player currentPlayer)
        {
            currentPlayer.Attack(target);
            StartCoroutine(WaitTime());
        }
    }

    private void Update()
    {
        var currentCharacter = turnManager.turnOrder[turnManager.currentTurnIndex];

        if (currentCharacter is Player currentPlayer)
        {
            if (Input.GetMouseButtonDown(0))
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

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(turnManager.NextTime());
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentTurnIndex = -1; 
    public List<object> turnOrder = new List<object>();
    public TurnDisplay turnDisplay;

    public void SetupTurnOrder(List<Player> playerTeam, List<Enemy> enemyTeam)
    {
        turnOrder.Clear();
        turnOrder.AddRange(playerTeam);
        turnOrder.AddRange(enemyTeam);
        turnOrder = turnOrder.OrderByDescending(c => (c is Player player) ? player.Speed : (c as Enemy).Speed).ToList();
    }

    public void NextTurn()
    {
        currentTurnIndex++;

        if (currentTurnIndex >= turnOrder.Count)
        {
            currentTurnIndex = 0;
        }

        object currentCharacter = turnOrder[currentTurnIndex];
        turnDisplay.UpdateCurrentTurn(currentCharacter);
        turnDisplay.UpdateTurnList(turnOrder, currentTurnIndex);

        Debug.Log($"{(currentCharacter is Player ? (currentCharacter as Player).CharacterName : (currentCharacter as Enemy).CharacterName)}의 턴입니다.");

        if (currentCharacter is Enemy enemy)
        {
            enemy.AttackRandomPlayer();
            StartCoroutine(WaitTime());
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f);
        NextTurn();
    }

}

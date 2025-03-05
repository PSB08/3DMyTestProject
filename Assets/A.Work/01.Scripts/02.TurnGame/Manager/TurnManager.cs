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
    public CamChange camChange;

    public void SetupTurnOrder(List<Player> playerTeam, List<Enemy> enemyTeam)
    {
        turnOrder.Clear();
        turnOrder.AddRange(playerTeam);
        turnOrder.AddRange(enemyTeam);
        turnOrder = turnOrder.OrderByDescending(c => (c is Player player) ? player.Speed : (c as Enemy).Speed).ToList();
    }

    public IEnumerator NextTime()
    {
        currentTurnIndex++;

        if (currentTurnIndex >= turnOrder.Count)
        {
            currentTurnIndex = 0;
        }

        object currentCharacter = turnOrder[currentTurnIndex];
        turnDisplay.UpdateCurrentTurn(currentCharacter);
        turnDisplay.UpdateTurnList(turnOrder, currentTurnIndex);

        yield return new WaitForSeconds(0.5f);

        Debug.Log($"{(currentCharacter is Player ? (currentCharacter as Player).CharacterName : (currentCharacter as Enemy).CharacterName)}의 턴입니다.");

        if (currentCharacter is Enemy enemy)
        {
            enemy.AttackRandomPlayer();
            yield return new WaitForSeconds(1f);
            StartCoroutine(NextTime());
        }
        if (currentCharacter is Player player)
        {
            camChange.mainCam.gameObject.SetActive(false);
            if (player.CharacterName.Contains("1"))
            {
                camChange.CameraSetting(1);
            }
            if (player.CharacterName.Contains("2"))
            {
                camChange.CameraSetting(2);
            }
            if (player.CharacterName.Contains("3"))
            {
                camChange.CameraSetting(3);
            }
            if (player.CharacterName.Contains("4"))
            {
                camChange.CameraSetting(4);
            }

        }
    }

}

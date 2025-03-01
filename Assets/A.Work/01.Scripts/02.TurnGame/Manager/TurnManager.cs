using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentTurnIndex = 0; // 현재 턴 인덱스
    public List<object> turnOrder = new List<object>(); // Player와 Enemy를 모두 포함할 수 있는 리스트

    public void SetupTurnOrder(List<Player> playerTeam, List<Enemy> enemyTeam)
    {
        turnOrder.AddRange(playerTeam);
        turnOrder.AddRange(enemyTeam);
        turnOrder = turnOrder.OrderByDescending(c => (c is Player player) ? player.Speed : (c as Enemy).Speed).ToList(); // 속도에 따라 정렬
    }

    public void NextTurn()
    {
        currentTurnIndex++;
        if (currentTurnIndex >= turnOrder.Count)
            currentTurnIndex = 0; // 인덱스를 0으로 초기화

        // 현재 턴의 캐릭터에게 행동할 기회를 줌
        object currentCharacter = turnOrder[currentTurnIndex];
        Debug.Log($"{(currentCharacter is Player ? (currentCharacter as Player).CharacterName : (currentCharacter as Enemy).CharacterName)}의 턴입니다.");

        // 적의 턴일 경우 자동으로 공격
        if (currentCharacter is Enemy enemy)
        {
            enemy.AttackRandomPlayer();
            StartCoroutine(WaitTime());
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        NextTurn(); // 적 공격 후 다음 턴으로 넘어가기
        yield return new WaitForSeconds(1.5f);
    }

}

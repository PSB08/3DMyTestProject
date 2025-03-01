using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentTurnIndex = -1; // 인덱스를 -1로 시작
    public List<object> turnOrder = new List<object>();
    public TurnDisplay turnDisplay; // TurnDisplay 클래스의 인스턴스 추가

    public void SetupTurnOrder(List<Player> playerTeam, List<Enemy> enemyTeam)
    {
        turnOrder.Clear(); // 기존 리스트 초기화
        turnOrder.AddRange(playerTeam);
        turnOrder.AddRange(enemyTeam);
        turnOrder = turnOrder.OrderByDescending(c => (c is Player player) ? player.Speed : (c as Enemy).Speed).ToList();
    }

    public void NextTurn()
    {
        // 현재 턴 인덱스 업데이트
        currentTurnIndex++;

        // 리스트의 끝에 도달하면 처음으로 돌아가기
        if (currentTurnIndex >= turnOrder.Count)
        {
            currentTurnIndex = 0;
        }

        // 현재 턴 캐릭터 가져오기
        object currentCharacter = turnOrder[currentTurnIndex];
        turnDisplay.UpdateCurrentTurn(currentCharacter); // 현재 턴 업데이트
        turnDisplay.UpdateTurnList(turnOrder, currentTurnIndex); // 턴 리스트 업데이트

        Debug.Log($"{(currentCharacter is Player ? (currentCharacter as Player).CharacterName : (currentCharacter as Enemy).CharacterName)}의 턴입니다.");

        if (currentCharacter is Enemy enemy)
        {
            enemy.AttackRandomPlayer(); // 적이 랜덤 플레이어를 공격
            StartCoroutine(WaitTime());
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f); // 공격 후 대기 시간
        NextTurn(); // 다음 턴으로 이동
    }

}

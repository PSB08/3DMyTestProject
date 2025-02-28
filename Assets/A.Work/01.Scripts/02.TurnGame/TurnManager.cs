using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private enum Turn { Player, Enemy }
    private Turn currentTurn;

    private void Start()
    {
        currentTurn = Turn.Player;
        Debug.Log("플레이어 턴 시작!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeTurn();
        }
    }

    private void ChangeTurn()
    {
        if (currentTurn == Turn.Player)
        {
            currentTurn = Turn.Enemy;
            Debug.Log("적 턴 시작!");
            EnemyTurn();
        }
        else
        {
            currentTurn = Turn.Player;
            Debug.Log("플레이어 턴 시작!");
        }
    }

    private void EnemyTurn()
    {
        // 간단한 AI 행동 (예: 플레이어에게 자동 공격)
        Debug.Log("적이 플레이어를 공격합니다!");
        Invoke("ChangeTurn", 1.5f); // 1.5초 후 다시 플레이어 턴으로 변경
    }

}

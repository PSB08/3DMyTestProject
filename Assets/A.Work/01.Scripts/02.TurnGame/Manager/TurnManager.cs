using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentTurnIndex = -1; // �ε����� -1�� ����
    public List<object> turnOrder = new List<object>();
    public TurnDisplay turnDisplay; // TurnDisplay Ŭ������ �ν��Ͻ� �߰�

    public void SetupTurnOrder(List<Player> playerTeam, List<Enemy> enemyTeam)
    {
        turnOrder.Clear(); // ���� ����Ʈ �ʱ�ȭ
        turnOrder.AddRange(playerTeam);
        turnOrder.AddRange(enemyTeam);
        turnOrder = turnOrder.OrderByDescending(c => (c is Player player) ? player.Speed : (c as Enemy).Speed).ToList();
    }

    public void NextTurn()
    {
        // ���� �� �ε��� ������Ʈ
        currentTurnIndex++;

        // ����Ʈ�� ���� �����ϸ� ó������ ���ư���
        if (currentTurnIndex >= turnOrder.Count)
        {
            currentTurnIndex = 0;
        }

        // ���� �� ĳ���� ��������
        object currentCharacter = turnOrder[currentTurnIndex];
        turnDisplay.UpdateCurrentTurn(currentCharacter); // ���� �� ������Ʈ
        turnDisplay.UpdateTurnList(turnOrder, currentTurnIndex); // �� ����Ʈ ������Ʈ

        Debug.Log($"{(currentCharacter is Player ? (currentCharacter as Player).CharacterName : (currentCharacter as Enemy).CharacterName)}�� ���Դϴ�.");

        if (currentCharacter is Enemy enemy)
        {
            enemy.AttackRandomPlayer(); // ���� ���� �÷��̾ ����
            StartCoroutine(WaitTime());
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f); // ���� �� ��� �ð�
        NextTurn(); // ���� ������ �̵�
    }

}

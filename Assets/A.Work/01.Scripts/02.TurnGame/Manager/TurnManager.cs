using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentTurnIndex = 0; // ���� �� �ε���
    public List<object> turnOrder = new List<object>(); // Player�� Enemy�� ��� ������ �� �ִ� ����Ʈ

    public void SetupTurnOrder(List<Player> playerTeam, List<Enemy> enemyTeam)
    {
        turnOrder.AddRange(playerTeam);
        turnOrder.AddRange(enemyTeam);
        turnOrder = turnOrder.OrderByDescending(c => (c is Player player) ? player.Speed : (c as Enemy).Speed).ToList(); // �ӵ��� ���� ����
    }

    public void NextTurn()
    {
        currentTurnIndex++;
        if (currentTurnIndex >= turnOrder.Count)
            currentTurnIndex = 0; // �ε����� 0���� �ʱ�ȭ

        // ���� ���� ĳ���Ϳ��� �ൿ�� ��ȸ�� ��
        object currentCharacter = turnOrder[currentTurnIndex];
        Debug.Log($"{(currentCharacter is Player ? (currentCharacter as Player).CharacterName : (currentCharacter as Enemy).CharacterName)}�� ���Դϴ�.");

        // ���� ���� ��� �ڵ����� ����
        if (currentCharacter is Enemy enemy)
        {
            enemy.AttackRandomPlayer();
            StartCoroutine(WaitTime());
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.5f);
        NextTurn(); // �� ���� �� ���� ������ �Ѿ��
        yield return new WaitForSeconds(1.5f);
    }

}

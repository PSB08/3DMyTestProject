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
        Debug.Log("�÷��̾� �� ����!");
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
            Debug.Log("�� �� ����!");
            EnemyTurn();
        }
        else
        {
            currentTurn = Turn.Player;
            Debug.Log("�÷��̾� �� ����!");
        }
    }

    private void EnemyTurn()
    {
        // ������ AI �ൿ (��: �÷��̾�� �ڵ� ����)
        Debug.Log("���� �÷��̾ �����մϴ�!");
        Invoke("ChangeTurn", 1.5f); // 1.5�� �� �ٽ� �÷��̾� ������ ����
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public List<Character> playerTeam = new List<Character>();
    public List<Character> enemyTeam = new List<Character>();
    public List<Character> turnOrder = new List<Character>();

    public Character currentCharacter;
    public bool isPlayerTurn;
    public bool isCombatActive;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // ���� ����
    public void StartCombat(List<Character> players, List<Character> enemies)
    {
        playerTeam = players;
        enemyTeam = enemies;
        isCombatActive = true;

        // �ʱ� �� ���� ����
        CalculateTurnOrder();

        // ù �� ����
        StartNextTurn();
    }

    // �� ���� ��� (�ӵ� ���)
    public void CalculateTurnOrder()
    {
        // ��� ĳ���͸� �ϳ��� ����Ʈ�� ��ġ��
        List<Character> allCharacters = new List<Character>();
        allCharacters.AddRange(playerTeam.Where(p => p.gameObject.activeSelf));
        allCharacters.AddRange(enemyTeam.Where(e => e.gameObject.activeSelf));

        // �ӵ��� ���� �������� ����
        turnOrder = allCharacters.OrderByDescending(c => c.speed).ToList();

        // ��� ĳ������ �� ��� ���� �ʱ�ȭ
        foreach (Character c in turnOrder)
        {
            c.hasTakenTurn = false;
        }

        // UI ������Ʈ
        //CombatUIManager.Instance.UpdateTurnOrderUI(turnOrder);
    }

    // ���� �� ����
    public void StartNextTurn()
    {
        // ��� ĳ���Ͱ� ���� ����ߴ��� Ȯ��
        if (turnOrder.All(c => c.hasTakenTurn))
        {
            // �� ���� ����
            CalculateTurnOrder();
        }

        // ���� ������� ���� ù ��° ĳ���� ����
        currentCharacter = turnOrder.FirstOrDefault(c => !c.hasTakenTurn);

        if (currentCharacter != null)
        {
            currentCharacter.hasTakenTurn = true;
            isPlayerTurn = currentCharacter.isPlayerTeam;

            // UI ������Ʈ
            //CombatUIManager.Instance.UpdateCurrentTurnUI(currentCharacter);

            // �÷��̾� ���̸� �Է� Ȱ��ȭ, �� ���̸� AI �ൿ
            if (isPlayerTurn)
            {
                EnablePlayerInput();
            }
            else
            {
                StartCoroutine(ExecuteEnemyTurn());
            }
        }
        else
        {
            // ��� ĳ���Ͱ� ���� ����� ��� (�� ���� ���� �ʾƾ� ��)
            Debug.LogError("No character available for next turn!");
            CalculateTurnOrder();
            StartNextTurn();
        }
    }

    // �÷��̾� �Է� Ȱ��ȭ
    void EnablePlayerInput()
    {
        // �÷��̾ ���� ������ �� �ֵ��� ��
        //InputManager.Instance.EnableTargetSelection(true);
    }

    // �� AI �� ����
    IEnumerator ExecuteEnemyTurn()
    {
        yield return new WaitForSeconds(1f); // ��� ���

        // ����ִ� �÷��̾� ĳ���� �� �ϳ��� �����ϰ� ����
        List<Character> alivePlayerCharacters = playerTeam.Where(p => p.gameObject.activeSelf && p.currentHealth > 0).ToList();

        if (alivePlayerCharacters.Count > 0)
        {
            Character target = alivePlayerCharacters[Random.Range(0, alivePlayerCharacters.Count)];

            // Ÿ�ٿ��� �̵��Ͽ� ����
            yield return StartCoroutine(currentCharacter.MoveToTargetAndAttack(target));
        }
        else
        {
            // ��� �÷��̾ ����� ��� ���� ����
            EndCombat(false);
        }
    }

    // �� ����
    public void EndTurn()
    {
        // ���� �� ����
        StartNextTurn();

        // ���� ���� ���� Ȯ��
        CheckCombatEnd();
    }

    // ĳ���� ��� ó��
    public void CharacterDied(Character character)
    {
        // ���� ���� ���� Ȯ��
        CheckCombatEnd();
    }

    // ���� ���� ���� Ȯ��
    void CheckCombatEnd()
    {
        // ��� �÷��̾ ����ߴ��� Ȯ��
        if (playerTeam.All(p => !p.gameObject.activeSelf || p.currentHealth <= 0))
        {
            EndCombat(false); // �й�
        }

        // ��� ���� ����ߴ��� Ȯ��
        if (enemyTeam.All(e => !e.gameObject.activeSelf || e.currentHealth <= 0))
        {
            EndCombat(true); // �¸�
        }
    }

    // ���� ����
    void EndCombat(bool isVictory)
    {
        isCombatActive = false;

        // ��� UI ǥ��
        //CombatUIManager.Instance.ShowCombatResult(isVictory);
    }
}

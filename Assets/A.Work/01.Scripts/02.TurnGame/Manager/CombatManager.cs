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

    // 전투 시작
    public void StartCombat(List<Character> players, List<Character> enemies)
    {
        playerTeam = players;
        enemyTeam = enemies;
        isCombatActive = true;

        // 초기 턴 순서 설정
        CalculateTurnOrder();

        // 첫 턴 시작
        StartNextTurn();
    }

    // 턴 순서 계산 (속도 기반)
    public void CalculateTurnOrder()
    {
        // 모든 캐릭터를 하나의 리스트로 합치기
        List<Character> allCharacters = new List<Character>();
        allCharacters.AddRange(playerTeam.Where(p => p.gameObject.activeSelf));
        allCharacters.AddRange(enemyTeam.Where(e => e.gameObject.activeSelf));

        // 속도에 따라 내림차순 정렬
        turnOrder = allCharacters.OrderByDescending(c => c.speed).ToList();

        // 모든 캐릭터의 턴 사용 여부 초기화
        foreach (Character c in turnOrder)
        {
            c.hasTakenTurn = false;
        }

        // UI 업데이트
        //CombatUIManager.Instance.UpdateTurnOrderUI(turnOrder);
    }

    // 다음 턴 시작
    public void StartNextTurn()
    {
        // 모든 캐릭터가 턴을 사용했는지 확인
        if (turnOrder.All(c => c.hasTakenTurn))
        {
            // 새 라운드 시작
            CalculateTurnOrder();
        }

        // 턴을 사용하지 않은 첫 번째 캐릭터 선택
        currentCharacter = turnOrder.FirstOrDefault(c => !c.hasTakenTurn);

        if (currentCharacter != null)
        {
            currentCharacter.hasTakenTurn = true;
            isPlayerTurn = currentCharacter.isPlayerTeam;

            // UI 업데이트
            //CombatUIManager.Instance.UpdateCurrentTurnUI(currentCharacter);

            // 플레이어 턴이면 입력 활성화, 적 턴이면 AI 행동
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
            // 모든 캐릭터가 턴을 사용한 경우 (이 경우는 오지 않아야 함)
            Debug.LogError("No character available for next turn!");
            CalculateTurnOrder();
            StartNextTurn();
        }
    }

    // 플레이어 입력 활성화
    void EnablePlayerInput()
    {
        // 플레이어가 적을 선택할 수 있도록 함
        //InputManager.Instance.EnableTargetSelection(true);
    }

    // 적 AI 턴 실행
    IEnumerator ExecuteEnemyTurn()
    {
        yield return new WaitForSeconds(1f); // 잠시 대기

        // 살아있는 플레이어 캐릭터 중 하나를 랜덤하게 선택
        List<Character> alivePlayerCharacters = playerTeam.Where(p => p.gameObject.activeSelf && p.currentHealth > 0).ToList();

        if (alivePlayerCharacters.Count > 0)
        {
            Character target = alivePlayerCharacters[Random.Range(0, alivePlayerCharacters.Count)];

            // 타겟에게 이동하여 공격
            yield return StartCoroutine(currentCharacter.MoveToTargetAndAttack(target));
        }
        else
        {
            // 모든 플레이어가 사망한 경우 전투 종료
            EndCombat(false);
        }
    }

    // 턴 종료
    public void EndTurn()
    {
        // 다음 턴 시작
        StartNextTurn();

        // 전투 종료 조건 확인
        CheckCombatEnd();
    }

    // 캐릭터 사망 처리
    public void CharacterDied(Character character)
    {
        // 전투 종료 조건 확인
        CheckCombatEnd();
    }

    // 전투 종료 조건 확인
    void CheckCombatEnd()
    {
        // 모든 플레이어가 사망했는지 확인
        if (playerTeam.All(p => !p.gameObject.activeSelf || p.currentHealth <= 0))
        {
            EndCombat(false); // 패배
        }

        // 모든 적이 사망했는지 확인
        if (enemyTeam.All(e => !e.gameObject.activeSelf || e.currentHealth <= 0))
        {
            EndCombat(true); // 승리
        }
    }

    // 전투 종료
    void EndCombat(bool isVictory)
    {
        isCombatActive = false;

        // 결과 UI 표시
        //CombatUIManager.Instance.ShowCombatResult(isVictory);
    }
}

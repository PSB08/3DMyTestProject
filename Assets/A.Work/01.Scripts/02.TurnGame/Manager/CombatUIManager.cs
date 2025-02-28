using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{
    /*public static CombatUIManager Instance;

    // UI 요소들
    public Transform turnOrderPanel;
    public Transform currentTurnIndicator;
    public GameObject selectTargetHint;
    public GameObject combatResultPanel;
    public TMPro.TextMeshProUGUI combatResultText;
    public GameObject damagePrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // 턴 순서 UI 업데이트
    public void UpdateTurnOrderUI(List<Character> turnOrder)
    {
        // 기존 UI 삭제
        foreach (Transform child in turnOrderPanel)
        {
            Destroy(child.gameObject);
        }

        // 새 턴 순서 UI 생성
        // 실제 구현에서는 캐릭터 아이콘이나 이름을 표시하는 UI 요소 생성
    }

    // 현재 턴 UI 업데이트
    public void UpdateCurrentTurnUI(Character character)
    {
        // 현재 턴 캐릭터 표시
        // 실제 구현에서는 현재 캐릭터 이름, 아이콘 등을 UI에 표시
    }

    // 타겟 선택 힌트 표시
    public void ShowSelectTargetHint()
    {
        selectTargetHint.SetActive(true);
    }

    // 타겟 선택 힌트 숨기기
    public void HideSelectTargetHint()
    {
        selectTargetHint.SetActive(false);
    }

    // 전투 결과 표시
    public void ShowCombatResult(bool isVictory)
    {
        combatResultPanel.SetActive(true);
        combatResultText.text = isVictory ? "승리!" : "패배...";
    }

    // 데미지 텍스트 표시
    public void ShowDamageText(Vector3 position, int damage)
    {
        // 데미지 텍스트 생성 및 표시
        GameObject damageObj = Instantiate(damagePrefab, position + Vector3.up, Quaternion.identity);
        TMPro.TextMeshPro text = damageObj.GetComponent<TMPro.TextMeshPro>();

        if (text != null)
        {
            text.text = damage.ToString();
            // 2초 후에 파괴
            Destroy(damageObj, 2f);
        }
    }

    */
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnDisplay : MonoBehaviour
{
    public Image currentTurnImage; // 현재 턴 캐릭터의 이미지
    public TextMeshProUGUI currentTurnText; // 현재 턴 캐릭터의 이름
    public TextMeshProUGUI turnListText; // 턴 리스트를 표시할 TextMeshPro UI 요소

    public void UpdateCurrentTurn(object currentCharacter)
    {
        if (currentCharacter is Player player)
        {
            currentTurnText.text = player.CharacterName; // 캐릭터 이름 업데이트
        }
        else if (currentCharacter is Enemy enemy)
        {
            currentTurnText.text = enemy.CharacterName; // 적 캐릭터 이름 업데이트
        }
    }

    public void UpdateTurnList(List<object> turnOrder, int currentTurnIndex)
    {
        turnListText.text = ""; // 초기화

        // 순서대로 캐릭터 이름을 추가
        for (int i = 0; i < turnOrder.Count; i++)
        {
            string characterName = turnOrder[i] is Player
                ? (turnOrder[i] as Player).CharacterName
                : (turnOrder[i] as Enemy).CharacterName;

            if (i == currentTurnIndex)
            {
                turnListText.text += $"{characterName}\n\n"; // 현재 턴 표시
            }
            else
            {
                turnListText.text += $"{characterName}\n\n"; // 나머지 캐릭터 표시
            }
        }
    }

}

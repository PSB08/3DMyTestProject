using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnDisplay : MonoBehaviour
{
    public Image currentTurnImage;
    public TextMeshProUGUI currentTurnText;
    public TextMeshProUGUI turnListText;

    public void UpdateCurrentTurn(object currentCharacter)
    {
        if (currentCharacter is Player player)
        {
            currentTurnText.text = player.CharacterName;
        }
        else if (currentCharacter is Enemy enemy)
        {
            currentTurnText.text = enemy.CharacterName;
        }
    }

    public void UpdateTurnList(List<object> turnOrder, int currentTurnIndex)
    {
        turnListText.text = "";

        for (int i = 0; i < turnOrder.Count; i++)
        {
            string characterName = turnOrder[i] is Player
                ? (turnOrder[i] as Player).CharacterName
                : (turnOrder[i] as Enemy).CharacterName;

            if (i == currentTurnIndex)
            {
                turnListText.text += $"{characterName}\n\n";
            }
            else
            {
                turnListText.text += $"{characterName}\n\n";
            }
        }
    }

}

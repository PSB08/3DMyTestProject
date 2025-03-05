using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    public TeamManager teamManager;
    public TextMeshProUGUI victoryTxt;

    private void Start()
    {
        victoryTxt.enabled = false;
    }

    private void Update()
    {
        CheckTeamVictory();
    }

    private void CheckTeamVictory()
    {
        if (teamManager.playerTeam.Count <= 0)
        {
            victoryTxt.text = "Lose";
            StartCoroutine(TextCoroutine());
        }
        if (teamManager.enemyTeam.Count <= 0)
        {
            victoryTxt.text = "Victory";
            StartCoroutine(TextCoroutine());
        }
    }

    private IEnumerator TextCoroutine()
    {
        victoryTxt.enabled = true;
        yield return new WaitForSeconds(3f);
        victoryTxt.enabled = false;
    }

}

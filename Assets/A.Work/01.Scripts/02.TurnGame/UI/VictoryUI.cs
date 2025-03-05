using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(0);
        victoryTxt.enabled = false;
    }

}

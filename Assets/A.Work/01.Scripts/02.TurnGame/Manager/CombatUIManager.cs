using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{
    /*public static CombatUIManager Instance;

    // UI ��ҵ�
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

    // �� ���� UI ������Ʈ
    public void UpdateTurnOrderUI(List<Character> turnOrder)
    {
        // ���� UI ����
        foreach (Transform child in turnOrderPanel)
        {
            Destroy(child.gameObject);
        }

        // �� �� ���� UI ����
        // ���� ���������� ĳ���� �������̳� �̸��� ǥ���ϴ� UI ��� ����
    }

    // ���� �� UI ������Ʈ
    public void UpdateCurrentTurnUI(Character character)
    {
        // ���� �� ĳ���� ǥ��
        // ���� ���������� ���� ĳ���� �̸�, ������ ���� UI�� ǥ��
    }

    // Ÿ�� ���� ��Ʈ ǥ��
    public void ShowSelectTargetHint()
    {
        selectTargetHint.SetActive(true);
    }

    // Ÿ�� ���� ��Ʈ �����
    public void HideSelectTargetHint()
    {
        selectTargetHint.SetActive(false);
    }

    // ���� ��� ǥ��
    public void ShowCombatResult(bool isVictory)
    {
        combatResultPanel.SetActive(true);
        combatResultText.text = isVictory ? "�¸�!" : "�й�...";
    }

    // ������ �ؽ�Ʈ ǥ��
    public void ShowDamageText(Vector3 position, int damage)
    {
        // ������ �ؽ�Ʈ ���� �� ǥ��
        GameObject damageObj = Instantiate(damagePrefab, position + Vector3.up, Quaternion.identity);
        TMPro.TextMeshPro text = damageObj.GetComponent<TMPro.TextMeshPro>();

        if (text != null)
        {
            text.text = damage.ToString();
            // 2�� �Ŀ� �ı�
            Destroy(damageObj, 2f);
        }
    }

    */
}

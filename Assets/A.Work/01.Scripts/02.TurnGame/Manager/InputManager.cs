using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public LayerMask enemyLayer;
    public bool canSelectTarget;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        // Ÿ�� ������ Ȱ��ȭ�� ���
        if (canSelectTarget && Input.GetMouseButtonDown(0))
        {
            // ����ĳ��Ʈ�� �� ĳ���� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, enemyLayer))
            {
                // Ŭ���� �� ĳ���� ��������
                Character enemyCharacter = hit.collider.GetComponent<Character>();

                if (enemyCharacter != null && !enemyCharacter.isPlayerTeam)
                {
                    // Ÿ�� ���� ��Ȱ��ȭ
                    //EnableTargetSelection(false);

                    // ���� ĳ���Ͱ� Ÿ������ �̵��Ͽ� ����
                    StartCoroutine(CombatManager.Instance.currentCharacter.MoveToTargetAndAttack(enemyCharacter));
                }
            }
        }
    }

    /*public void EnableTargetSelection(bool enable)
    {
        canSelectTarget = enable;

        // UI ��Ʈ ǥ��
        if (enable)
            CombatUIManager.Instance.ShowSelectTargetHint();
        else
            CombatUIManager.Instance.HideSelectTargetHint();
    }*/


}

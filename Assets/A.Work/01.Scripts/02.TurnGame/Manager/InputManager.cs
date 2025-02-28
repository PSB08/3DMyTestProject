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
        // 타겟 선택이 활성화된 경우
        if (canSelectTarget && Input.GetMouseButtonDown(0))
        {
            // 레이캐스트로 적 캐릭터 감지
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, enemyLayer))
            {
                // 클릭한 적 캐릭터 가져오기
                Character enemyCharacter = hit.collider.GetComponent<Character>();

                if (enemyCharacter != null && !enemyCharacter.isPlayerTeam)
                {
                    // 타겟 선택 비활성화
                    //EnableTargetSelection(false);

                    // 현재 캐릭터가 타겟으로 이동하여 공격
                    StartCoroutine(CombatManager.Instance.currentCharacter.MoveToTargetAndAttack(enemyCharacter));
                }
            }
        }
    }

    /*public void EnableTargetSelection(bool enable)
    {
        canSelectTarget = enable;

        // UI 힌트 표시
        if (enable)
            CombatUIManager.Instance.ShowSelectTargetHint();
        else
            CombatUIManager.Instance.HideSelectTargetHint();
    }*/


}

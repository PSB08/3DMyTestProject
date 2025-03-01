using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthText : MonoBehaviour
{
    public Enemy enemy;
    public TextMeshProUGUI healthText;
    private RectTransform rectTransform;

    private void Start()
    {
        healthText = GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = healthText.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (enemy != null)
        {
            healthText.text = $"{enemy.Health}";
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        // 적의 위치 위쪽으로 텍스트를 위치시킵니다.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemy.transform.position);
        rectTransform.position = new Vector3(screenPosition.x + 50, screenPosition.y + 100, screenPosition.z); // 50은 텍스트를 적의 위쪽으로 이동시키는 오프셋입니다.
    }

}

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
            healthText.color = enemy.nameMat.color;
            healthText.text = $"{enemy.Health}";
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        // ���� ��ġ �������� �ؽ�Ʈ�� ��ġ��ŵ�ϴ�.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemy.transform.position);
        rectTransform.position = new Vector3(screenPosition.x + 50, screenPosition.y + 100, screenPosition.z);
    }

}

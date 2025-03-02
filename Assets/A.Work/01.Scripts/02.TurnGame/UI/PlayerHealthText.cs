using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthText : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI healthText;
    private RectTransform rectTransform;

    private void Start()
    {
        healthText = GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = healthText.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (player != null)
        {
            healthText.text = $"{player.Health}";
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        // ���� ��ġ �������� �ؽ�Ʈ�� ��ġ��ŵ�ϴ�.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(player.transform.position);
        rectTransform.position = new Vector3(screenPosition.x + 50, screenPosition.y + 130, screenPosition.z);
    }
}

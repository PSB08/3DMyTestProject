using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpText : MonoBehaviour
{
    public HpSystem hpSystem;
    public TextMeshProUGUI hpText;

    private void Update()
    {
        hpText.text = $"HP : {hpSystem.currentHealth.ToString("F0")}";
    }

}

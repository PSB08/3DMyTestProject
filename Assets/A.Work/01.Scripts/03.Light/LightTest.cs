using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest : MonoBehaviour
{
    [SerializeField] private Light testLight;
    [SerializeField] private Color color;
    public int value;
    private bool isOn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnOff();
            isOn = !isOn;
        }
        testLight.color = color;
    }

    private void OnOff()
    {
        if (isOn)
            testLight.intensity = 0;
        else
            testLight.intensity = value;
    }

}

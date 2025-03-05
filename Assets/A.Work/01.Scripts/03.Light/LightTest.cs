using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest : MonoBehaviour
{
    [SerializeField] private Light testLight;
    public int value;
    private bool isOn;

    private void Start()
    {
        StartCoroutine(ChangeColor());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnOff();
            isOn = !isOn;
        }
    }

    private void OnOff()
    {
        if (isOn)
            testLight.intensity = 0;
        else
            testLight.intensity = value;
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            Color randomColor = GetRandomColorInHSV();
            testLight.color = randomColor;

            yield return new WaitForSeconds(0.5f);
        }
    }

    private Color GetRandomColorInHSV()
    {
        float h = Random.Range(0f, 1f);

        return Color.HSVToRGB(h, 1, 1);
    }

}

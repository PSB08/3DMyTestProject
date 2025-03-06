using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaTest1 : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 2f;
    }

    private void Update()
    {
        Debug.Log($"{Time.deltaTime}");
    }

}

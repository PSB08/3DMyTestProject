using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{
    [SerializeField] private List<Camera> cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].enabled = (i == 0);
        }
    }

    private void Update()
    {
        // F 키를 누를 때마다 다음 카메라로 변경
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Count;
            SwitchCamera(currentCameraIndex);
        }
    }

    private void SwitchCamera(int index)
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].enabled = (i == index);
        }
    }

}

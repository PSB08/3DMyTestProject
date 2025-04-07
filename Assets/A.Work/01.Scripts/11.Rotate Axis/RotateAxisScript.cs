using System;
using UnityEngine;

namespace Scripts.RotateAxis
{
    public class RotateAxisScript : MonoBehaviour
    {
        private ViewSwitchCollider[] viewSwitchObjects;

        public Camera mainCamera;
        private bool is3DMode = false;

        private void Awake()
        {
            viewSwitchObjects = FindObjectsOfType<ViewSwitchCollider>();
        }

        private void Start()
        {
            ApplyView(); // 시작할 때 현재 뷰에 맞게 설정
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchView();
            }
        }

        private void SwitchView()
        {
            is3DMode = !is3DMode;
            ApplyView();
        }

        private void ApplyView()
        {
            mainCamera.orthographic = !is3DMode;
            mainCamera.transform.position = is3DMode ? new Vector3(0, 5, -10) : new Vector3(0, 0, -10);
            mainCamera.transform.rotation = is3DMode ? Quaternion.Euler(20, 0, 0) : Quaternion.Euler(0, 0, 0);

            foreach (var obj in viewSwitchObjects)
            {
                obj.SetView(is3DMode);
            }
        }
        
    }    
}


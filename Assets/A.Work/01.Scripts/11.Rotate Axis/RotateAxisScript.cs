using System;
using UnityEngine;

namespace Scripts.RotateAxis
{
    public class RotateAxisScript : MonoBehaviour
    {
        private ViewSwitchCollider[] allSwitchables;
        
        public Camera mainCamera;
        private bool is2D = true;

        private void Awake()
        {
            allSwitchables = FindObjectsOfType<ViewSwitchCollider>();
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
            is2D = !is2D;

            mainCamera.orthographic = is2D;
            mainCamera.transform.position = is2D ? new Vector3(0, 0, -10) : new Vector3(0, 5, -10);
            mainCamera.transform.rotation = is2D ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(20, 0, 0);

            foreach (var s in allSwitchables) s.SetView(is2D);
        }
    }    
}


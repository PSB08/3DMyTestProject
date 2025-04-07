using System;
using UnityEngine;

namespace Scripts.RotateAxis
{
    public class RotateAxisScript : MonoBehaviour
    {
        public Camera mainCamera;
        private bool is2D = true;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchView();
            }
        }

        private void SwitchView()
        {
            if (is2D)
            {
                //2D
                mainCamera.orthographic = false; 
                mainCamera.transform.position = new Vector3(0, 5, -10);
                mainCamera.transform.rotation = Quaternion.Euler(20, 0, 0);
            }
            else
            {
                //3D
                mainCamera.orthographic = true;
                mainCamera.transform.position = new Vector3(0, 0, -10);
                mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            is2D = !is2D;
        }
    }    
}


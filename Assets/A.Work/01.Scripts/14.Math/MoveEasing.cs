using System;
using UnityEngine;

namespace Scripts.Math
{
    public class MoveEasing : MonoBehaviour
    {
        private void Update()
        {
            transform.Translate(Vector3.right * (5 * Time.deltaTime));
        }
        
    }
}
using System;
using UnityEngine;

namespace Scripts.CustomEditor
{
    public class ItemClass : MonoBehaviour
    {
        public int ID;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                if (gameObject != null)
                    gameObject.name = value;
            }
        }
    
    }    
}



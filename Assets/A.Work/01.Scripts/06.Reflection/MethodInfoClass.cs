using System;
using System.Reflection;
using UnityEngine;

namespace ReflectTest.CreateInstance
{
    class Profile2
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public void Print()
        {
            Debug.Log($"{Name}, {Phone}");
        }
        
    }

    public class MethodInfoClass : MonoBehaviour
    {
        private void Start()
        {
            Type type = typeof(Profile2);
            Profile2 profile2 = (Profile2)Activator.CreateInstance(type);
            profile2.Name = "홍OO";
            profile2.Phone = "010 - 1234 - 1234";
            
            MethodInfo method = type.GetMethod("Print");
            method.Invoke(profile2, null);
        }
    }   
}


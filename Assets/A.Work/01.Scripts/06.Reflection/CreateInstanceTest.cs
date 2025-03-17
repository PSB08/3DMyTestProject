using System;
using System.Reflection;
using UnityEngine;

namespace ReflectTest.CreateInstance
{
    class Profile
    {
        public string Name { get; set; }   
        public string PhoneNum { get; set; }   
    }

    public class CreateInstanceTest : MonoBehaviour
    {
        private void Start()
        {
            Type type = typeof(Profile);
            object profile = Activator.CreateInstance(type);

            PropertyInfo name = type.GetProperty("Name");
            PropertyInfo phoneNum = type.GetProperty("PhoneNum");

            name.SetValue(profile, "홍길동", null);
            phoneNum.SetValue(profile, "010-1234-1234", null);

            Debug.Log($"{name.GetValue(profile, null)}, {phoneNum.GetValue(profile, null)}");
        }


    }
}

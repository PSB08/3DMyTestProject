using System;
using System.Reflection;
using UnityEngine;

namespace GetType
{
    public class MainReflection : MonoBehaviour
    {
        private void Start()
        {
            int a = 0;
            Type type = a.GetType();

            PrintInterfaces(type);
            PrintFields(type);

            Type b = typeof(int);
            Console.WriteLine(b.Name);
        }

        private static void PrintInterfaces(Type type)
        {
            Debug.Log("-----Interfaces-----");

            Type[] interfaces = type.GetInterfaces();

            foreach (Type i in interfaces)
            {
                Debug.Log($"Name : {i.Name}");
            }
            Debug.Log("");
        }

        static void PrintFields(Type type)
        {
            Debug.Log("-----Fields-----");

            FieldInfo[] fields = type.GetFields
                (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                String accessLevel = "protected";

                if (field.IsPublic) accessLevel = "public";
                else if (field.IsPrivate) accessLevel = "private";

                Debug.Log($"Access : {accessLevel}, Type : {field.FieldType.Name}, Name : {field.Name}");

            }
            Debug.Log("");
        }


    }
}



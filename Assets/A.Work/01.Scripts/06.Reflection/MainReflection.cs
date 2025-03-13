using System;
using System.Reflection;
using UnityEngine;

namespace GetType
{
    public class MainReflection : MonoBehaviour
    {
        static void PrintInterfaces(Type type)
        {
            Console.WriteLine("-----Interfaces-----");

            Type[] interfaces = type.GetInterfaces();

            foreach (Type i in interfaces)
            {
                Console.WriteLine($"Name : {0}", i.Name);
            }
            Console.WriteLine();
        }

        static void PrintFields(Type type)
        {
            Console.WriteLine("-----Fields-----");

            FieldInfo[] fields = type.GetFields
                (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                String accessLevel = "protected";

                if (field.IsPublic) accessLevel = "public";
                else if (field.IsPrivate) accessLevel = "private";

                Console.WriteLine($"Access : {0}, Type : {1}, Name : {2}", accessLevel, field.FieldType.Name, field.Name);

            }
            Console.WriteLine();
        }



    }
}



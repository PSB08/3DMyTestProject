using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Generics
{
    public class ObservableCode : MonoBehaviour
    {
        [field: SerializeField] public ObservableCollection<string> Names { get; set; }

        private void Awake()
        {
            Names = new ObservableCollection<string>
            {
                "PSB", "ISSAC", "CIW", "PSW", "CSH"
            };
        }

        private void Update()
        {
            Names.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Debug.Log("Item add");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Debug.Log("Item remove");
                        break;
                }
            };

            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                AddName("A");
            }
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                RemoveName("A");
            }
            if (Keyboard.current.cKey.wasPressedThisFrame)
            {
                Names.Clear();
            }

            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                foreach (var value in Names)
                {
                    Debug.Log(value);
                }
            }
        }

        public void AddName(string name)
        {
            Names.Add(name);
        }

        public void RemoveName(string name)
        {
            Names.Remove(name);
        }
        
        
    }
}
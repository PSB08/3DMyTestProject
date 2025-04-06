using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace Code.FSM.Editor
{
    [UnityEditor.CustomEditor(typeof(StateDataSO))]
    public class StateDataEditor : UnityEditor.Editor
    {
        [SerializeField] private VisualTreeAsset uiAsset = default;
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();
            uiAsset.CloneTree(root);

            DropdownField classField = root.Q<DropdownField>("ClassDropdownField");
            
            classField.choices.Clear();
            
            Assembly fsmAssembly = Assembly.GetAssembly(typeof(EntityState_9));
            
            List<Type> stateTypes = fsmAssembly.GetTypes()
                .Where(type =>  type.IsAbstract == false
                                && type.IsSubclassOf(typeof(EntityState_9)))
                .ToList();

            stateTypes.ForEach(type => classField.choices.Add(type.FullName));
            
            return root;
        }
    }
}
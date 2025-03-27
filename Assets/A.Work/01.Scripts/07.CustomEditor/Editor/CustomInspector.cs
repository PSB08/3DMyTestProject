using System;
using UnityEditor;
using UnityEngine;

public class CustomInspector : EditorWindow
{
    private int itemID;
    private string itemName;
    
    [MenuItem("Window/Custom Inspector")]
    private static void OpenWindow()
    {
        GetWindow(typeof(CustomInspector));
    }

    private void OnGUI()
    {
        GUILayout.Label("아이템 설명", EditorStyles.boldLabel);
        
        itemID = EditorGUILayout.IntField("ID", itemID);
        itemName = EditorGUILayout.TextField("Name", itemName);

        if (GUILayout.Button("생성하기"))
        {
            CreateItem();
        }
        
    }

    private void CreateItem()
    {
        GameObject newItem = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        ItemClass itemClass = newItem.AddComponent<ItemClass>();
        
        itemClass.ID = itemID;
        itemClass.Name = itemName;
        
        Selection.activeGameObject = newItem;
    }
    
}

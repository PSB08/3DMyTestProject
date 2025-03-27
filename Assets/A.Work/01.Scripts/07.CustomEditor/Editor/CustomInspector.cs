using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Scripts.CustomEditor
{
    public class CustomInspector : EditorWindow
    {
        private int itemID;
        private string itemName;
        public PrimitiveType shape = PrimitiveType.Cube;
        private ItemClass[] _itemClasses;

        private void Awake()
        {
            _itemClasses = FindObjectsOfType<ItemClass>();
        }

        [MenuItem("MyEditor/MakeShape", priority = 0)]
        private static void OpenWindow()
        {
            GetWindow(typeof(CustomInspector));
        }

        private void OnGUI()
        {
            GUILayout.Label("아이템 설명", EditorStyles.boldLabel);
        
            itemID = EditorGUILayout.IntField("오브젝트 ID", itemID);
            itemName = EditorGUILayout.TextField("오브젝트 이름", itemName);
            
            shape = (PrimitiveType)EditorGUILayout.EnumPopup("오브젝트 모양", shape);
            EditorGUILayout.Space(15);

            if (GUILayout.Button("생성하기"))
            {
                CreateItem();
            }
        
        }
        
        private void CreateItem()
        {
            ItemClass existItem = _itemClasses.FirstOrDefault(item => item.ID == itemID);

            if (existItem != null)
            {
                Undo.RecordObject(existItem, "Modify Item");
                existItem.Name = itemName;
                ReplaceObjectShape(existItem.gameObject);
                EditorUtility.SetDirty(existItem);
            }
            else
            {
                GameObject newItem = GameObject.CreatePrimitive(shape);
                ItemClass item = newItem.AddComponent<ItemClass>();
            
                item.ID = itemID;
                item.Name = itemName;
            
                newItem.name = itemName;
                Selection.activeGameObject = newItem;
            }
        }
    
        private void ReplaceObjectShape(GameObject obj)
        {
            if (obj == null) return;
            
            DestroyImmediate(obj.GetComponent<MeshFilter>());
            DestroyImmediate(obj.GetComponent<MeshRenderer>());
            DestroyImmediate(obj.GetComponent<Collider>());
            
            GameObject newShape = GameObject.CreatePrimitive(shape);
            
            obj.AddComponent<MeshFilter>().sharedMesh = newShape.GetComponent<MeshFilter>().sharedMesh;
            obj.AddComponent<MeshRenderer>().sharedMaterials = newShape.GetComponent<MeshRenderer>().sharedMaterials;
            
            Collider newCollider = newShape.GetComponent<Collider>();
            if (newCollider != null)
            {
                Collider addedCollider = obj.AddComponent(newCollider.GetType()) as Collider;
                EditorUtility.CopySerialized(newCollider, addedCollider);
            }
            
            DestroyImmediate(newShape);
        }
        
    }    
}


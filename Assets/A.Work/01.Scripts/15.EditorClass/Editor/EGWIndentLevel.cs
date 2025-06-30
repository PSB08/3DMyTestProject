using UnityEditor;
using UnityEngine;

namespace Scripts.EditorClass
{
    public class EGWIndentLevel : EditorWindow
    {
        [MenuItem("Window/EGW/EGWIndentLevel")]
        static void Open()
        {
            GetWindow<EGWIndentLevel>();
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Parent");

            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Child");
            EditorGUILayout.LabelField("Child");

            EditorGUI.indentLevel--;
            EditorGUILayout.LabelField("Parent");

            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Child");
        }
    }
}
using UnityEditor;
using UnityEngine;

namespace Scripts.EditorClass
{
    public class EGWMultiFloatField : EditorWindow
    {
        float[] numbers = new float[] {0,1,2};

        GUIContent[] contents = new GUIContent[] {
            new GUIContent ("X"),
            new GUIContent ("Y"),
            new GUIContent ("Z")};



        [MenuItem("Window/EGW/EGWMultiFloatField")]
        static void Open()
        {
            GetWindow<EGWMultiFloatField>();
        }

        void OnGUI()
        {
            EditorGUI.MultiFloatField(
                new Rect(30, 30, 200, EditorGUIUtility.singleLineHeight),
                new GUIContent("Label"),
                contents,
                numbers);
        }
    }
}
using UnityEditor;
using UnityEngine;

namespace Scripts.EditorClass
{
    public class EGWKnob : EditorWindow
    {
        float angle = 0;

        [MenuItem("Window/EGW/EGWKnob")]
        static void Open()
        {
            GetWindow<EGWKnob>();
        }

        void OnGUI()
        {
            angle = EditorGUILayout.Knob(Vector2.one * 64, angle, 0, 360, "도", Color.gray, Color.red, true);
        }
    }
}
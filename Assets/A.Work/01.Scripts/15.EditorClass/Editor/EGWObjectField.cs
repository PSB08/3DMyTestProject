using UnityEditor;
using UnityEngine;

namespace Scripts.EditorClass
{
    public class EGWObjectField : EditorWindow
    {
        [MenuItem("Window/EGW/EGWObjectField")]
        private static void Open()
        {
            GetWindow<EGWObjectField>();
        }

        private void OnGUI()
        {
            EditorGUILayout.ObjectField(null, typeof(Object), false);
            EditorGUILayout.ObjectField(null, typeof(Material), false);
            EditorGUILayout.ObjectField(null, typeof(AudioClip), false);

            var options = new[] { GUILayout.Width(64), GUILayout.Height(64) };

            EditorGUILayout.ObjectField(null, typeof(Texture), false, options);
            EditorGUILayout.ObjectField(null, typeof(Sprite), false, options);
        }
    
    }
}
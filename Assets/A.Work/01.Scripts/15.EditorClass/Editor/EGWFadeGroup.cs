using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.EditorClass
{
    public class EGWFadeGroup : EditorWindow
    {
        [MenuItem("Window/EGW/EGWFadeGroup")]
        static void Open()
        {
            GetWindow<EGWFadeGroup>();
        }

        private AnimFloat _animFloat = new AnimFloat(0.0001f);
        private Texture _tex;
        
        
        private void OnGUI()
        {
            bool isOpen = _animFloat.value == 1;
            _animFloat.speed = 0.5f;

            if (GUILayout.Button(isOpen ? "Close" : "Open", GUILayout.Width(64)))
            {
                _animFloat.target = isOpen ? 0.0001f : 1f;

                var env = new UnityEvent();
                env.AddListener(() => Repaint());
                _animFloat.valueChanged = env;
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginFadeGroup(_animFloat.value);
            Display();
            EditorGUILayout.EndFadeGroup();
            Display();
            EditorGUILayout.EndHorizontal();
        }
     
        private void Display()
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.ToggleLeft("Toggle", false);
            var options = new[] { GUILayout.Width(128), GUILayout.Height(128) };
            _tex = EditorGUILayout.ObjectField(_tex, typeof(Texture), false, options) as Texture;
            GUILayout.Button("Button");
            EditorGUILayout.EndVertical();
        }
        
        
    }
}

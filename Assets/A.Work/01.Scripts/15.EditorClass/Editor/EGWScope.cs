using UnityEditor;
using UnityEngine;

namespace Scripts.EditorClass
{
    public class EGWScope : EditorWindow
    {
        [MenuItem("Window/EGW/EGWScope")]
        static void Open()
        {
            GetWindow<EGWScope>();
        }

        void OnGUI()
        {
            using (new BackgroundColorScope(Color.green))
            {
                GUILayout.Button("Button1");
                using (new BackgroundColorScope(Color.yellow))
                {
                    GUILayout.Button("Button2");
                }
            }
        }
    }
}

public class HorizontalScope : GUI.Scope
{
    public HorizontalScope()
    {
        EditorGUILayout.BeginHorizontal();
    }
    
    protected override void CloseScope()
    {
        EditorGUILayout.EndHorizontal();   
    }
}

public class BackgroundColorScope : GUI.Scope
{
    private readonly Color _originalColor;

    public BackgroundColorScope(Color newColor)
    {
        _originalColor = GUI.backgroundColor;
        GUI.backgroundColor = newColor;
    }

    protected override void CloseScope()
    {
        GUI.backgroundColor = _originalColor;
    }
}
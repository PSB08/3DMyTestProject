using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityToolbarExtender;

[InitializeOnLoad]
public class CustomStartScene : MonoBehaviour
{
    static CustomStartScene()
    {
        ToolbarExtender.RightToolbarGUI.Add(OnToolBarGUI);
    }

    static void OnToolBarGUI()
    {
        GUILayout.FlexibleSpace();

        if (GUILayout.Button(new GUIContent("▷현재씬")))
        {
            EditorSceneManager.playModeStartScene = null;
            UnityEditor.EditorApplication.isPlaying = true;
        }

        if (GUILayout.Button(new GUIContent("▶메인씬")))
        {
            var pathOfMainScene = "Assets/A.Work/00.Scene/00.Test.Unity";
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfMainScene);
            EditorSceneManager.playModeStartScene = sceneAsset;
            UnityEditor.EditorApplication.isPlaying = true;
        }
        
    }
    
}

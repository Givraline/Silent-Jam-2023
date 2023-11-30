using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEditor.PackageManager.UI;
using System.IO;
using static UnityEngine.GraphicsBuffer;

public class MelodyCreatorWindow : EditorWindow
{
    public static void Init()
    {
        MelodyCreatorWindow window = GetWindowWithRect<MelodyCreatorWindow>(new Rect(0, 0, 500, 700), false);
        window.Show();
    }

    private void OnGUI()
    {
        //List<Object> existingData = AssetDatabase.LoadAllAssetsAtPath("Assets/Resources/Melodies/DONTDELETE.asset").ToList();
        List<Object> existingData = Directory.GetFiles("Assets/Resources/Melodies", "*.asset", SearchOption.TopDirectoryOnly).Select(f => AssetDatabase.LoadAssetAtPath(f, typeof(Object))).ToList();
        if (GUILayout.Button("Create new melody"))
        {
            MelodyData newMelody = CreateInstance<MelodyData>();
            newMelody.Melody = new();
            AssetDatabase.CreateAsset(newMelody, $"Assets/Resources/Melodies/Melody{existingData.Count}.asset");
            AssetDatabase.SaveAssets();

            existingData.Add(newMelody);
            //existingData = AssetDatabase.LoadAllAssetsAtPath("Assets/Resources/Melodies/").ToList();
        }

        for (int i = 0; i < existingData.Count; i++)
        {
            Object asset = existingData[i];

            GUI.backgroundColor = new Color(0f, 0f, 0f);
            GUILayout.BeginVertical("HelpBox");


            GUILayout.Label("Melody n°"+i, new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Italic, normal = new GUIStyleState() { textColor = new Color(1, 0.8f, 0.4f) } });

            GUI.backgroundColor = new Color(1f, 0.5f, 0.6f);
            if (GUILayout.Button("X", GUILayout.Width(50)))
            {
                if (EditorUtility.DisplayDialog("Confirmation",
                "Are you sure you want to delete melody. This action can't be undone.", "Delete", "Cancel"))
                {

                    existingData.Remove(asset);
                }
            }
            GUI.backgroundColor = new Color(0.5f, 0.5f, 0.9f);
            if (GUILayout.Button("Edit Melody"))
            {
                Selection.activeObject = asset;
                EditorGUIUtility.PingObject(asset);
            }
            EditorGUILayout.EndVertical();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.WSA;

[CustomEditor(typeof(MelodyCreator))]
public class MelodyCreatorEditor : Editor
{
    public bool lol;
    [SerializeField]
    SerializedProperty _melody;

    Object _scriptableObjectRef;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.Label("Create your own melody!", new GUIStyle(GUI.skin.label) { fontSize = 17, fontStyle = FontStyle.Bold });

        _melody = serializedObject.FindProperty("_melodyData");
        if (_melody.objectReferenceValue != null)
            _scriptableObjectRef = _melody.objectReferenceValue;

        if (_scriptableObjectRef == null)
        {
            EditorGUILayout.HelpBox("No melody: You have to assign a melody or create one!", MessageType.Warning, true);
        }

        _scriptableObjectRef = EditorGUILayout.ObjectField("Melody that will play in game:", _scriptableObjectRef, typeof(MelodyData), false);
        if(_scriptableObjectRef != null)
            _melody.objectReferenceValue = _scriptableObjectRef;

        if (GUILayout.Button("Create/Edit Melody"))
        {
            MelodyCreatorWindow.Init();
        }
        GUI.backgroundColor = new Color(0f, 0.5f, 0f);
        if (GUILayout.Button("Go to melodies folder for assignation"))
        {
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath("Assets/Resources/Melodies", typeof(UnityEngine.Object));
            Selection.activeObject = obj;
            EditorGUIUtility.PingObject(obj);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            serializedObject.ApplyModifiedProperties();
        }
    }
}

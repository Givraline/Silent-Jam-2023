using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System;
using Unity.VisualScripting;
using Unity.EditorCoroutines.Editor;
using TMPro.EditorUtilities;

[CustomEditor(typeof(MelodyData))]
public class MelodyDataInspector : Editor
{
    public NoteData NoteData;
    public bool _bool;
    bool _record = false;
    public override void OnInspectorGUI()
    {
        MelodyData data = (MelodyData)target;

        if (NoteData.AllSounds.Count == 0)
            return;

        GUILayout.BeginHorizontal();
        for (int i = 0; i < NoteData.AllSounds.Count; i++)
        {
            AudioClip sound = NoteData.AllSounds[i];
            if (GUILayout.Button((i+1).ToString(), GUILayout.Width(50)))
            {
                EditorSFX.PlayClip(sound);
                if(_record)
                    data.Melody.Add(sound);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Label("Check the box to record Melody (press buttons above like piano keys :)" , new GUIStyle(GUI.skin.label) { fontSize = 17, fontStyle = FontStyle.Bold });
        GUILayout.Label("(You can change the notes sounds in Assets/Data/NoteData)" , new GUIStyle(GUI.skin.label) { fontSize = 14, fontStyle = FontStyle.Italic });
        GUILayout.BeginHorizontal();
        _record = EditorGUILayout.Toggle(_record, GUILayout.Height(50));
        GUILayout.EndHorizontal();


        GUILayout.BeginVertical("HelpBox");
        for (int i = 0; i < data.Melody.Count; i++)
        {
            AudioClip note = data.Melody[i];
            GUILayout.BeginHorizontal("GroupBox");
            GUILayout.Label(note.name, new GUIStyle(GUI.skin.label) { fontSize = 17, fontStyle = FontStyle.Bold });

            if (GUILayout.Button("X", GUILayout.Width(50)))
            {
                data.Melody.Remove(note);
            }
            GUILayout.EndHorizontal();
        }
        GUI.backgroundColor = new Color(0.6f, 0.6f, 0.8f);
        if (GUILayout.Button("Play whole melody"))
        {
            EditorCoroutineUtility.StartCoroutine(EditorSFX.PlayListAudio(data.Melody.ToArray()),this);
        }

        GUI.backgroundColor = new Color(0.8f, 0.6f, 0.6f);
        if (GUILayout.Button("Stop Playing"))
        {
            EditorSFX.StopAllClips();
        }
        GUILayout.EndVertical();
    }
}

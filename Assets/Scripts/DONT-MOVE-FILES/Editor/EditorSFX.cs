using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Collections;
using Unity.VisualScripting;
using Unity.EditorCoroutines.Editor;

public static class EditorSFX
{
    static bool _play = true;
    public static void PlayClip(AudioClip clip, int startSample = 0, bool loop = false)
    {
        Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;

        Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
        MethodInfo method = audioUtilClass.GetMethod(
            "PlayPreviewClip",
            BindingFlags.Static | BindingFlags.Public,
            null,
            new Type[] { typeof(AudioClip), typeof(int), typeof(bool) },
            null
        );

        method.Invoke(
            null,
            new object[] { clip, startSample, loop }
        );
    }
    public static IEnumerator PlayListAudio(AudioClip[] sounds)
    {
        _play = true;
        foreach (AudioClip sound in sounds)
        {
            if(_play == false)
            {
                break;
            }
            PlayClip(sound);
            yield return new EditorWaitForSeconds(sound.length);
        }
    }


    public static void StopAllClips()
    {
        _play = false;
        Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;

        Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
        MethodInfo method = audioUtilClass.GetMethod(
            "StopAllPreviewClips",
            BindingFlags.Static | BindingFlags.Public,
            null,
            new Type[] { },
            null
        );

        method.Invoke(
            null,
            new object[] { }
        );
    }
}
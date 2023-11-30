using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NoteData", menuName = "Datas/Create NoteData", order = 1)]
public class NoteData : ScriptableObject
{
    public List<AudioClip> AllSounds
    {
        get => _allSounds;
    }
    [SerializeField]
    private List<AudioClip> _allSounds;
}

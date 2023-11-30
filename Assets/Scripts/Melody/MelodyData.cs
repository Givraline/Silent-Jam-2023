using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodyData : ScriptableObject
{
    public List<AudioClip> Melody
    {
        get => _melody; 
        set => _melody = value;
    }

    private List<AudioClip> _melody;
}

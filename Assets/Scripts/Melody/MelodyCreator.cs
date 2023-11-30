using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodyCreator : MonoBehaviour
{
    [SerializeField]
    private Object _melodyData;

    public List<AudioClip> Melody => ((MelodyData)_melodyData).Melody;

}

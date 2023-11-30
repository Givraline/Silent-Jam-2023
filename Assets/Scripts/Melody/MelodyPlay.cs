using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodyPlay : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private MelodyCreator meloScript;
    private int meloLength;

    public int MeloLength { get => meloLength; set => meloLength = value; }
    public AudioSource AudioS { get => audioS; set => audioS = value; }

    // Start is called before the first frame update
    void Start()
    {
        AudioS = this.GetComponent<AudioSource>();
        MeloLength = meloScript.Melody.Count;
    }

    public void PlaySong(int noteNumber)
    {
        AudioS.clip = meloScript.Melody[noteNumber];
        AudioS.Play();
    }
}

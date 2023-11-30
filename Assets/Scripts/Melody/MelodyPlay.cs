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
    private void Awake()
    {
        MeloLength = meloScript.Melody.Count;
        AudioS = this.GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        MeloLength = meloScript.Melody.Count;
        Debug.Log(MeloLength);
    }

    public void PlaySong(int noteNumber)
    {
        AudioS.clip = meloScript.Melody[noteNumber];
        AudioS.Play();
    }
}

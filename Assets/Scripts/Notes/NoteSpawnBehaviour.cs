using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] spawnArray;
    [SerializeField] private GameObject note;
    [SerializeField] private MelodyPlay melodyPlay;
    private int meloLength = 0;
    Coroutine c;

    // Start is called before the first frame update
    void Start()
    {
        StartNoteWait();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartNoteWait()
    {
        c = StartCoroutine(NoteWait());
    }

    void RestartNoteWait()
    {
        if(c != null) StopCoroutine(c);
        StartNoteWait();
    }

    IEnumerator NoteWait()
    {
        if(meloLength < melodyPlay.MeloLength)
        {
            Instantiate(note, spawnArray[Random.Range(0, spawnArray.Length)].transform.position, Quaternion.identity);
            melodyPlay.PlaySong(meloLength);
            meloLength++;
            yield return new WaitForSeconds(melodyPlay.AudioS.clip.length);
        }
        RestartNoteWait();
    }
}

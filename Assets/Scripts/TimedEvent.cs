using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class TimedEvent : MonoBehaviour
{
    
    public bool Free { get; private set; }
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    private AudioSource _audioSource;

    public List<AudioClip> possibleSounds;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Free = true;
    }

    public bool TryStartTimedEvent()
    {
        if (!Free) return false;
        StopCoroutine(StartEvent());
        return true;
    }

    private IEnumerator StartEvent()
    {
        Free = false;
        float timeToWait = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timeToWait);
        float clipLength = PlaySound();
        yield return new WaitForSeconds(clipLength);
        Free = true;
    }

    private void OnValidate()
    {
        if (minTime < 0) minTime = 0;
        if (maxTime < minTime) maxTime = minTime;
    }

    private float PlaySound()
    {
        int clipIndex = Random.Range(0, possibleSounds.Count);
        AudioClip clip = possibleSounds[clipIndex];
        _audioSource.PlayOneShot(clip);
        return clip.length;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using JimJam.Utility;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject audioObj;
    [SerializeField] private AudioClip[] sfx;
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySoundAtLocation(int clip, Vector2 location)
    {
        var obj = Instantiate(audioObj);
        obj.transform.position = location;
        obj.GetComponent<AudioSource>().PlayOneShot(sfx[clip]);
        obj.GetComponent<SelfDestruct>().TriggerDestruct(sfx[clip].length);
    }
}

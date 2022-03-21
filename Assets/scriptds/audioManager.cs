using UnityEngine.Audio;
using UnityEngine;
using System;

public class audioManager : MonoBehaviour
{
    public sound[] sounds;

    private void Awake()
    {
        foreach (sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }

    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }
}

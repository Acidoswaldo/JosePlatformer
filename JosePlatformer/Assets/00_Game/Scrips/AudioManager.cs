using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour

{

    public Sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }




        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.myAudioMixer;

        }
    }

    // Update is called once per frame
    void Start()
    {
        Play("Theme");
    }
    public static void StaticPlay(string name)
    {
        instance.Play(name);
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.Log("Sound with name " + name + " was not found");
        }

    }

}

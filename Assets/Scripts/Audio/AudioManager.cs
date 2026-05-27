using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

	public static AudioManager singletonInstance;
	
    void Awake()
    {
		if (singletonInstance != null) 
		{ 
			Destroy(this.gameObject); 
		} 
		else 
		{ 
			singletonInstance = this; 
			DontDestroyOnLoad(gameObject);
		} 

        foreach (Sound s in sounds)
        {
			GameObject isntance = new GameObject();
			AudioSource newSource = isntance.AddComponent<AudioSource>();
            s.SetSource(newSource);
			DontDestroyOnLoad(newSource.gameObject);
			
            s.GetSource().clip = s.GetClip();
            s.GetSource().volume = s.GetVolume();
            s.GetSource().pitch = s.GetPitch();
            s.GetSource().loop = s.GetLoop();
        }
    }

    private void Start()
    {
        //Play("Menu");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "lvl1")
        {
            Stop("Menu");
        }
    }

    public void Play(string name)
	{
        Sound s = FindSoundByName(name);
		if(s != null)
			s.GetSource().Play();
    }

    public void Stop(string name)
	{
        Sound s = FindSoundByName(name);
		if(s != null)
			s.GetSource().Stop();
    }
	
	private Sound FindSoundByName(string name)
	{
		return Array.Find(sounds, sound => sound.GetClip().name == name);
	}
}
using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Custom/Sound")]
public class Sound : ScriptableObject
{
    [SerializeField] private AudioClip clip;

    [Range(0f, 3f)]
    [SerializeField] private float volume;
	
    [Range(-3f, 3f)]
    [SerializeField] private float pitch;
	
    [SerializeField] private bool loop;
	
	private AudioSource source;
	
	public AudioClip GetClip()
	{
		return clip;
	}
	
	public float GetVolume()
	{
		return volume;
	}
	
	public float GetPitch()
	{
		return pitch;
	}
	
	public bool GetLoop()
	{
		return loop;
	}
	
	public AudioSource GetSource()
	{
		return source;
	}
	
	public void SetSource(AudioSource newValue) {
		source = newValue;
	}
}
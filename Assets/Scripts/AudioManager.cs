using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public static AudioManager am;
    public AudioMixer mixer;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip music;
    public AudioClip deathSound;
    public AudioClip victorySound;

	void Awake() 
    {
        //DontDestroyOnLoad(this.gameObject);
	}

    void Start()
    {
        if (!am)
        {
            am = this;
            musicSource.Play();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
	
    public void SetMusicLevel(float musicLevel) //Sets Music track level in AudioMixer
    {
        mixer.SetFloat("musicVol", musicLevel);
    }

    public void SetEffectsLevel(float effectsLevel) //Sets Effects track level in AudioMixer
    {
        mixer.SetFloat("sfxVol", effectsLevel);
    }
}

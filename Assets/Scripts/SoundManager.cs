using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _soundInstance;
    public static SoundManager SoundInstance
    {
        get
        {
            if (_soundInstance == null)
                Debug.Log("SoundManager is null");
            return _soundInstance;
        }
    }

    //Make the Singleton
    public void Awake()
    {
        if (_soundInstance != null)
        {
            Destroy(this.gameObject);
            Debug.Log("Instance destroyed");
        }
        else
        {
            _soundInstance = this;
            Debug.Log("Instance created");
        }
    }


    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _voiceSource;
    [SerializeField] private AudioSource _soundSource;

    private void Start() {
        _soundSource.loop = true;
        Debug.Log("AudioSources status : ");
        Debug.Log("AudioSource : " + _audioSource);
        Debug.Log("MusicSource : " + _musicSource);
        Debug.Log("VoiceSource : " + _voiceSource);
        Debug.Log("SoundSource : " + _soundSource);
    }

    public void PlaySound(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
    public void StopSounds()
    {
        _audioSource.Stop();
    }

    public void PlayMusic(AudioClip firstMusic, AudioClip music)
    {
        if(!_musicSource.isPlaying) {
            _musicSource.clip = firstMusic;
            _musicSource.Play();
        }
        
        StartCoroutine(AfterPlayed(_musicSource, () => {
            _musicSource.clip = music;
            _musicSource.loop = true;
            _musicSource.Play();
        }));
        
    }

    IEnumerator AfterPlayed(AudioSource audioSource, System.Action action) {
        yield return new WaitWhile(() => audioSource.isPlaying);
        action();
    }

    public void StopMusics()
    {
        _musicSource.Stop();
    }

    public void PlayVoice(AudioClip voice)
    {
        _voiceSource.PlayOneShot(voice);
    }
    public void StopVoices()
    {
        _voiceSource.Stop();
    }

    public void PlayAmbiantSound(AudioClip ambiantSound)
    {
        _soundSource.clip = ambiantSound;
        _soundSource.Play();
    }

    public void StopAmbiantSound()
    {
        _soundSource.Stop();
    }
}

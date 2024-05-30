using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        PlayBackgroundMusic();
        MusicVolume();
        SfxVolume();
        musicSource.loop = true;
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayMainMusic()
    {
        PlayMusic("main");
    }

    public void PlayBackgroundMusic()
    {
        if (SceneManager.GetActiveScene().name == "Main" || SceneManager.GetActiveScene().name == "LevelSeclection")
        {
            PlayMusic("main");
        }
        else
        {
            int randomMusic = UnityEngine.Random.Range(0, 2);
            if (randomMusic == 0)
            {
                PlayMusic("gameScence1");
            }
            else
            {
                PlayMusic("gameScence2");
            }
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySfx(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void MusicVolume()
    {
        musicSource.volume = Audio.instance.GetMusic();
    }

    public void SfxVolume()
    {
        sfxSource.volume = Audio.instance.GetSfx();
    }
}

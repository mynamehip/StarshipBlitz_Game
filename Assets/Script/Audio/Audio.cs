using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance { get; private set; }

    public float music;
    public float sfx;

    private void Awake()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 1);
            PlayerPrefs.SetFloat("Sfx", 1);
            music = 1;
            sfx = 1;
        }
        else
        {
            music = PlayerPrefs.GetFloat("Music");
            sfx = PlayerPrefs.GetFloat("Sfx");
        }
    }

    private void Start()
    {
    }

    public float GetMusic()
    {
        return music;
    }

    public void SetMusic(float music)
    {
        this.music = music;
        PlayerPrefs.SetFloat("Music", music);
    }

    public float GetSfx()
    {
        return sfx;
    }

    public void SetSfx(float sfx)
    {
        this.sfx = sfx;
        PlayerPrefs.SetFloat("Sfx", sfx);
    }
}

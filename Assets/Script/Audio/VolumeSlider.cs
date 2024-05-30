using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;

    private void Start()
    {
        SetVolume();
    }

    public void SetVolume()
    {
        musicSlider.value = Audio.instance.GetMusic();
        sfxSlider.value = Audio.instance.GetSfx();
    }

    public void ChangeMusic()
    {
        AudioController.instance.MusicVolume();
        Audio.instance.SetMusic(musicSlider.value);
    }

    public void ChangeSfx()
    {
        AudioController.instance.SfxVolume();
        Audio.instance.SetSfx(sfxSlider.value);
    }
}

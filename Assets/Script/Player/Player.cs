using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object
{
    public int currentSprite;
    SpriteRenderer spriteRenderer;
    Skin skin;

    private void Awake()
    {
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Skin"))
        {
            currentSprite = PlayerPrefs.GetInt("Skin");
        }
        else
        {
            currentSprite = 0;
        }
        PlayerData.instance.SetSkin(currentSprite);
        PlayerData.instance.SetWeaponType(currentSprite + 1);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        skin = gameObject.GetComponent<Skin>();
        spriteRenderer.sprite = skin.sprites[currentSprite];
    }

    public int GetSkin()
    {
        return currentSprite;
    }

    public void SetSkin(int i)
    {
        currentSprite = i;
        PlayerPrefs.SetInt("Skin", currentSprite);
        spriteRenderer.sprite = skin.sprites[i];
    }

    public int GetHeart()
    {
        return heart;
    }

    public void SetHeart(int heart)
    {
        this.heart = heart;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}

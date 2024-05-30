using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayer : MonoBehaviour
{
    Player p;
    SpriteRenderer spriteRenderer;
    int skinNumber;
    int skinIndex;

    void Start()
    {
        p = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = PlayerData.instance.GetSkin();
        skinNumber = PlayerData.instance.GetSkinNumber();
        skinIndex = PlayerData.instance.GetSkinIndex();
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();

    public List<Sprite> GetSkin()
    {
        return sprites;
    }
}

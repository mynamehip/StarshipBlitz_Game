using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set; }

    public static int skinIndex = 0;
    public List<Sprite> skins;
    public static int weaponType = 1;
    public static int weaponLevel = 0;

    public static int deadEnemy = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        deadEnemy = PlayerPrefs.GetInt("DeadEnemy");
    }

    void Update()
    {
        
    }

    public void ChangeDeadEnemy()
    {
        deadEnemy++;
        PlayerPrefs.SetInt("DeadEnemy", deadEnemy);
        if (deadEnemy == 50)
        {
            ChangeAchivement(0);
        }
        if (deadEnemy == 100)
        {
            ChangeAchivement(1);
        }
        if (deadEnemy == 200)
        {
            ChangeAchivement(2);
        }
    }

    public void ChangeAchivement(int index)
    {
        string a = PlayerPrefs.GetString("Achivement");
        char[] c = a.ToCharArray();
        c[index] = '1';
        a = new string(c);
        PlayerPrefs.SetString("Achivement", a);
    }

    public int GetSkinNumber()
    {
        return skins.Count;
    }

    public int GetSkinIndex()
    {
        return skinIndex;
    }

    public Sprite GetSkin()
    {
        return skins[skinIndex];
    }

    public void SetSkin(int i)
    {
        skinIndex = i;
    }

    public int GetWaeponType()
    {
        return weaponType;
    }

    public void SetWeaponType(int i)
    {
        weaponType = i;
    }

    public int GetWeaponLevel()
    {
        return weaponLevel;
    }

    public void SetWeaponLevel(int i)
    {
        weaponLevel = i;
    }
}

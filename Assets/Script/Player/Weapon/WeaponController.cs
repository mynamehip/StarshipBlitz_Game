using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    int weaponType;
    int weaponLevel;
    bool isTouchingScreen;
    bool isLaunching = false;

    public List<GameObject> bullet;

    private void Start()
    {
        weaponType = PlayerData.instance.GetWaeponType();
        weaponLevel = PlayerData.instance.GetWeaponLevel();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isTouchingScreen = true;
                    if (!isLaunching)
                    {
                        StartCoroutine(Launch());
                    }
                    break;
                case TouchPhase.Ended:
                    isTouchingScreen = false;
                    break;
            }
        }
    }

    IEnumerator Launch()
    {
        isLaunching = true;
        while (isTouchingScreen && Time.timeScale != 0)
        {
            switch (weaponType)
            {
                case 1:
                    Bullet();
                    AudioController.instance.PlaySfx("playerShoot1");
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 2:
                    Rocket();
                    AudioController.instance.PlaySfx("playerShoot2");
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 3:
                    Plasma();
                    AudioController.instance.PlaySfx("playerShoot3");
                    yield return new WaitForSeconds(0.75f);
                    break;
            }
        }
        isLaunching = false;
    }

    void Bullet()
    {
        if(weaponLevel == 0)
        {
            Instantiate(bullet[weaponType - 1], transform.position + new Vector3(-0.3f, 0, 0), Quaternion.identity);
            Instantiate(bullet[weaponType - 1], transform.position + new Vector3(0.3f, 0, 0), Quaternion.identity);
        }
        else if(weaponLevel == 1)
        {
            Instantiate(bullet[weaponType - 1], transform.position + new Vector3(-0.3f, 0, 0), Quaternion.identity);
            Instantiate(bullet[weaponType - 1], transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            Instantiate(bullet[weaponType - 1], transform.position + new Vector3(0.3f, 0, 0), Quaternion.identity);
        }
        else if (weaponLevel == 2)
        {
            Instantiate(bullet[weaponType - 1], transform.position + new Vector3(-0.5f, 0, 0), Quaternion.Euler(0, 0, 5));
            GameObject b = Instantiate(bullet[weaponType - 1], transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            b.transform.localScale = new Vector3(2f, 2f, 0);
            BulletController bc = b.GetComponent<BulletController>();
            bc.damage = 3;
            Instantiate(bullet[weaponType - 1], transform.position + new Vector3(0.5f, 0, 0), Quaternion.Euler(0, 0, -5));
        }
    }

    void Rocket()
    {
        if (weaponLevel == 0)
        {
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, 10));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.identity);
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, -10));
        }
        else if (weaponLevel == 1)
        {
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, 14));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, 7));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.identity);
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, -7));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, -14));
        }
        else if (weaponLevel == 2)
        {
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, 15));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, 10));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, 5));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.identity);
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, -5));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, -10));
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.Euler(0, 0, -15));
        }
    }

    void Plasma()
    {
        if (weaponLevel == 0)
        {
            Instantiate(bullet[weaponType - 1], transform.position, Quaternion.identity);
        }
        else if (weaponLevel == 1)
        {
            GameObject b = Instantiate(bullet[weaponType - 1], transform.position, Quaternion.identity);
            b.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            BulletController bc = b.GetComponent<BulletController>();
            bc.damage = 2;
        }
        else if (weaponLevel == 2)
        {
            GameObject b = Instantiate(bullet[weaponType - 1], transform.position, Quaternion.identity);
            b.transform.localScale = new Vector3(2f, 2f, 0);
            BulletController bc = b.GetComponent<BulletController>();
            bc.damage = 3;
        }
    }

    void UpdateWeapon(int index)
    {
        if(weaponType == index)
        {
            if(weaponLevel < 2)
            {
                weaponLevel++;
            }
            PlayerData.instance.SetWeaponLevel(weaponLevel);
        }
        else
        {
            weaponType = index;
            PlayerData.instance.SetWeaponType(weaponType);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layer = LayerMask.LayerToName(collision.gameObject.layer);
        if(layer == "Item")
        {
            ItemController ic = collision.GetComponent<ItemController>();
            int weaponIndex = ic.index;
            Destroy(collision.gameObject);
            UpdateWeapon(weaponIndex);
        }
    }
}

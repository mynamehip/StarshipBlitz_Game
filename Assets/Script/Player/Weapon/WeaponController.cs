using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator ani;
    public enum WeaponType
    {
        BigBullet,
        Rocket,
        PlasmaBall
    }
    public WeaponType weapon;
    public List<Sprite> weaponSprites = new List<Sprite>();
    public List<GameObject> bulletType = new List<GameObject>();

    int weaponIndex;
    
    float bigBulletTimer = 0f;
    float rocketTimer = 0f;
    float plasmaBallTimer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        weaponIndex = Array.IndexOf(Enum.GetValues(typeof(WeaponType)), weapon);
        if(weaponIndex == 0)
        {
            ani.SetTrigger("ToBigBullet");
        }
        else if (weaponIndex == 1)
        {
            ani.SetTrigger("ToRocket");
        }
        else if(weaponIndex == 2)
        {
            ani.SetTrigger("ToPlasmaBall");
        }
    }

    void Update()
    {
        weaponIndex = Array.IndexOf(Enum.GetValues(typeof(WeaponType)), weapon);
        spriteRenderer.sprite = weaponSprites[weaponIndex];

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            LaunchBullet(weaponIndex);
        }
        bigBulletTimer -= Time.deltaTime;
        rocketTimer -= Time.deltaTime;
        plasmaBallTimer -= Time.deltaTime;
    }

    void LaunchBullet(int bulletIndex)
    {
        if(bulletIndex == 0 && bigBulletTimer < 0)
        {
            StartCoroutine(LaunchBigBullet(bulletIndex));
            StartCoroutine(WeaponAnimation(0.35f));
            bigBulletTimer = 0.5f;
        }
        if (bulletIndex == 1 && rocketTimer < 0)
        {
            StartCoroutine(LaunchRocket(bulletIndex));
            StartCoroutine(WeaponAnimation(1.2f));
            rocketTimer = 1.2f;
        }
        if (bulletIndex == 2 && plasmaBallTimer < 0)
        {
            StartCoroutine(LaunchPlasmaBall(bulletIndex));
            StartCoroutine(WeaponAnimation(1f));
            plasmaBallTimer = 1f;
        }
    }

    IEnumerator LaunchBigBullet(int bulletIndex)
    {
        yield return new WaitForSeconds(0.05f);
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(-0.25f, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(0.25f, 0, 0), Quaternion.identity);
    }

    IEnumerator LaunchRocket(int bulletIndex)
    {
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(-0.25f, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(0.25f, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(-0.25f, 0, 0), Quaternion.Euler(0, 0, 10));
        yield return new WaitForSeconds(0.15f);
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(0.25f, 0, 0), Quaternion.Euler(0, 0, -10));
        yield return new WaitForSeconds(0.15f);
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(-0.25f, 0, 0), Quaternion.Euler(0, 0, 20));
        yield return new WaitForSeconds(0.15f);
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(0.25f, 0, 0), Quaternion.Euler(0, 0, -20));
    }

    IEnumerator LaunchPlasmaBall(int bulletIndex)
    {
        float angleOffset = UnityEngine.Random.Range(-20f, 20f);
        Quaternion rotation = Quaternion.Euler(0f, 0f, angleOffset);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bulletType[bulletIndex], transform.position + new Vector3(0, 0.35f, 0), rotation);
    }

    IEnumerator WeaponAnimation(float animationTimer)
    {
        ani.SetBool("isShotting", true);
        yield return new WaitForSeconds(animationTimer);
        ani.SetBool("isShotting", false);
    }
}

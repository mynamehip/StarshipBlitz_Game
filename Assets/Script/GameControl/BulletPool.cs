using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public static BulletPool BulletInstance;
    public List<GameObject> bullets;
    public GameObject bullet;
    public int amountToPool;

    void Awake()
    {
        BulletInstance = this;
    }

    void Start()
    {
        bullets = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(bullet);
            tmp.SetActive(false);
            bullets.Add(tmp);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }
}

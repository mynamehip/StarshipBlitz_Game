using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemyController : MonoBehaviour
{
    public GameController gc;

    float timer = 1f;
    bool isClear = false;
    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0 && !isClear)
        {
            CheckEnemy();
            timer = 1f;
        }
    }

    void CheckEnemy()
    {
        int k = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.activeInHierarchy)
            {
                k++;
            }
        }
        if(k == 0)
        {
            gc.ClearedEnemy();
            isClear = true;
        }
    }
}

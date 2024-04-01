using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;
    float timer = 2f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
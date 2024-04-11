using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int damage;
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
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}

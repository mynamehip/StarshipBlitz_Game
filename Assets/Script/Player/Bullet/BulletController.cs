using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int damage;
    public bool isPlasma;
    public ParticleSystem vfx;
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

    public void Effect()
    {
        if(!isPlasma)
        {
            Instantiate(vfx, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(vfx, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;
    public int damage;
    public float liveTime;
    public ParticleSystem vfx;

    void Update()
    {
        liveTime -= Time.deltaTime;
        if (liveTime < 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    public void Effect()
    {
         Instantiate(vfx, transform.position, Quaternion.identity);
    }
}

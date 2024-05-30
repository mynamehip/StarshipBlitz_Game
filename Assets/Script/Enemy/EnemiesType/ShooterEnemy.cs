using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : EnemyController
{
    public GameObject bullet;
    float attackTimer;
    public float bulletDistance;

    void Start()
    {
        attackTimer = Random.Range(1f, 10f);
    }


    new void Update()
    {
        base.Update();
        if(!isControlling)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer <= 0 )
        {
            Launch();
            attackTimer = Random.Range(5f, 15f);
        }
    }

    void Launch()
    {
        AudioController.instance.PlaySfx("enemyShoot1");
        if (isFollwing)
        {
            Instantiate(bullet, transform.position - new Vector3(0, bulletDistance, 0), Quaternion.Euler(0f, 0f, rotationAngle - 180));
        }
        else
        {
            Instantiate(bullet, transform.position - new Vector3(0, bulletDistance, 0), Quaternion.identity);
        }
    }
}

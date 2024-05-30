using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RocketEnemy : EnemyController
{
    public GameObject bullet;
    float attackTimer;
    new Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
        attackTimer = Random.Range(1f, 5f);
    }

    new void Update()
    {
        base.Update();
        if (!isControlling)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer <= 0)
        {
            StartCoroutine(LaunchRocket());
            StartCoroutine(ShootingAnimation(1.2f));
            attackTimer = Random.Range(3f, 7f);
        }
    }

    IEnumerator LaunchRocket()
    {
        AudioController.instance.PlaySfx("enemyShoot2");
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet, transform.position + new Vector3(-0.25f, 0, 0), Quaternion.Euler(0, 0, -5));
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, transform.position + new Vector3(0.25f, 0, 0), Quaternion.Euler(0, 0, 5));
        yield return new WaitForSeconds(0.15f);
        Instantiate(bullet, transform.position + new Vector3(-0.45f, 0, 0), Quaternion.Euler(0, 0, -10));
        yield return new WaitForSeconds(0.15f);
        Instantiate(bullet, transform.position + new Vector3(0.45f, 0, 0), Quaternion.Euler(0, 0, 10));
        yield return new WaitForSeconds(0.15f);
        Instantiate(bullet, transform.position + new Vector3(-0.65f, 0, 0), Quaternion.Euler(0, 0, -15));
        yield return new WaitForSeconds(0.15f);
        Instantiate(bullet, transform.position + new Vector3(0.65f, 0, 0), Quaternion.Euler(0, 0, 15));
    }

    IEnumerator ShootingAnimation(float animationTimer)
    {
        ani.SetBool("isShooting", true);
        yield return new WaitForSeconds(animationTimer);
        ani.SetBool("isShooting", false);
    }
}

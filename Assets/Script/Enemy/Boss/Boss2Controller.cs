using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss2Controller : BossController
{
    public GameObject littleBullet;
    public GameObject bomb;
    public GameObject bomb2;

    void Start()
    {
        attackTimer = 2f;
        isFinish = true;
    }

    void Update()
    {
        if (isFinish)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer < 0)
        {
            AttackPlayer();
            attackTimer = Random.Range(1f, 3f);
        }
        if (!isStopRotate)
        {
            Rotate();
        }
    }

    void AttackPlayer()
    {
        isFinish = false;
        int randomMove = Random.Range(0, 6);
        switch (randomMove)
        {
            case 0:
                StartCoroutine(Tackler());
                AudioController.instance.PlaySfx("enemyTackle1");
                break;
            case 1:
                StartCoroutine(Shooting());
                AudioController.instance.PlaySfx("enemyShoot1");
                break;
            case 2:
                StartCoroutine(Tackler());
                StartCoroutine(SpreadBomb());
                AudioController.instance.PlaySfx("enemyTackle1");
                break;
            case 3:
                StartCoroutine(SpreadBomb2());
                AudioController.instance.PlaySfx("enemyBomb1");
                break;
            case 4:
                StartCoroutine(SpreadBomb3());
                break;
            case 5:
                StartCoroutine(ShootMany());
                break;
        }
    }

    IEnumerator SpreadBomb()
    {
        while (!isFinish)
        {
            int spreadAngle = Random.Range(-180, 180);
            Instantiate(bomb, transform.position, Quaternion.Euler(0f, 0f, rotationAngle - spreadAngle));
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator SpreadBomb2()
    {
        isStopRotate = true;
        for(int i = 0; i < 720;)
        {
            Instantiate(bomb2, transform.position, Quaternion.Euler(0f, 0f, rotationAngle - 180 - i));
            i += 20;
            yield return new WaitForSeconds(0.1f);
        }
        isStopRotate = false;
        isFinish = true;
    }

    IEnumerator SpreadBomb3()
    {
        int spreadTime = 3;
        while (spreadTime > 0)
        {
            AudioController.instance.PlaySfx("enemyBomb1");
            isStopRotate = true;
            for (int i = 0; i < 360;)
            {
                Instantiate(bomb2, transform.position, Quaternion.Euler(0f, 0f, rotationAngle - 180 - i + spreadTime * 10));
                i += 20;
            }
            yield return new WaitForSeconds(0.75f);
            isStopRotate = false;
            spreadTime--;
        }
        isFinish = true;
    }

    IEnumerator ShootMany()
    {
        int i = 8;
        while (i > 0)
        {
            AudioController.instance.PlaySfx("enemyShoot2");
            Vector3 shotDirection = player.transform.position - transform.position;
            shotDirection.Normalize();
            Instantiate(littleBullet, transform.position + shotDirection * 1.5f, Quaternion.Euler(0f, 0f, rotationAngle - 150));
            Instantiate(littleBullet, transform.position + shotDirection * 1.5f, Quaternion.Euler(0f, 0f, rotationAngle - 180));
            Instantiate(littleBullet, transform.position + shotDirection * 1.5f, Quaternion.Euler(0f, 0f, rotationAngle - 210));
            i--;
            yield return new WaitForSeconds(0.5f);
        }
        isFinish = true;
    }
}

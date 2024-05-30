using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossController : Object
{
    public GameController gc;
    public ParticleSystem explo;
    protected float attackTimer;
    protected float rotationAngle;
    protected bool isFinish;
    protected bool isStopRotate;
    public GameObject player;
    public GameObject bullet;
    public GameObject drone;

    public Image heartBar;

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
        if (attackTimer < 0 )
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
        int randomMove = Random.Range(0, 3);
        switch (randomMove)
        {
            case 0:
                StartCoroutine(Tackler());
                AudioController.instance.PlaySfx("enemyTackle1");
                break;
            case 1:
                StartCoroutine(Shooting());
                break;
            case 2:
                StartCoroutine(LaunchDrone());
                break;
        }
    }

    public IEnumerator Tackler()
    {
        Vector2 playerPosition = Vector2.zero;
        if (player != null)
        {
            playerPosition = player.transform.position;
        }
        while ((Vector2)transform.position != playerPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, 5f * Time.deltaTime);
            yield return null;
        }
        isFinish = true;
    }

    public IEnumerator Shooting()
    {
        int i = 8;
        while(i > 0)
        {
            AudioController.instance.PlaySfx("enemyShoot1");
            Vector3 shotDirection = player.transform.position - transform.position;
            shotDirection.Normalize();
            Instantiate(bullet, transform.position + shotDirection * 1.8f, Quaternion.Euler(0f, 0f, rotationAngle - 180));
            i--;
            yield return new WaitForSeconds(0.5f);
        }
        isFinish = true;
    }

    public IEnumerator LaunchDrone()
    {
        isStopRotate = true;
        int i = 3;
        yield return new WaitForSeconds(0.5f);
        while (i > 0)
        {
            Vector3 shotDirection = player.transform.position - transform.position;
            shotDirection.Normalize();
            Instantiate(drone, transform.position, Quaternion.Euler(0f, 0f, rotationAngle - 90 * i));
            i--;
        }
        isStopRotate = false;
        isFinish = true;
        yield return new WaitForSeconds(0.5f);
    }

    public void Rotate()
    {
        Vector2 rotateDirection = player.transform.position - transform.position;
        rotateDirection.Normalize();
        rotationAngle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        rotationAngle -= 90;
        Quaternion newQuaternion = Quaternion.Euler(0f, 0f, rotationAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newQuaternion, 60f * Time.deltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        string layer = LayerMask.LayerToName(collision.gameObject.layer);
        if (layer == "PlayerBullet")
        {
            BulletController bulletController = collision.GetComponent<BulletController>();
            heart -= bulletController.damage;
            ChangeHeart();
            bulletController.Effect();
            if (!bulletController.isPlasma)
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            return;
        }

        if (heart <= 0)
        {
            int scenceIndex = SceneManager.GetActiveScene().buildIndex;
            if (scenceIndex == 6)
            {
                PlayerData.instance.ChangeAchivement(3);
            }
            else
            {
                PlayerData.instance.ChangeAchivement(4);
            }
            ParticleSystem ps = Instantiate(explo, transform.position, Quaternion.identity);
            var mainModule = ps.main;
            mainModule.startRotationX = 0;
            mainModule.startRotationY = 0;
            mainModule.startRotationZ = rotationAngle * Mathf.Deg2Rad;
            gc.Win();
            gameObject.SetActive(false);
        }
    }

    void ChangeHeart()
    {
        heartBar.fillAmount = (float)heart / 100;
    }
}

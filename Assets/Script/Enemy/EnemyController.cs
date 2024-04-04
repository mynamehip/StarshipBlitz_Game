using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Object
{
    Rigidbody2D obj;

    float timer;
    public float changeTime;
    public bool isRocket;
    public bool isFollwing;
    int direction = 1;
    float moveTimer;
    float rotationAngle = 0;

    Animator ani;

    //Vector2 currentPosition;
    public GameObject bullet;
    public GameObject enemyEffect;

    //AudioSource audioSource;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        //currentPosition = obj.position;
        timer = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (isRocket)
            {
                StartCoroutine(LaunchRocket());
                StartCoroutine(ShootingAnimation(1.2f));
            }
            else
            {
                Launch();
            }
            timer = Random.Range(2f, 5f);
        }

        moveTimer -= Time.deltaTime;
        if (moveTimer < 0)
        {
            direction = -direction;
            moveTimer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = obj.position;
        position.x = position.x + Time.deltaTime * speed * direction;
        obj.MovePosition(position);
        if (isFollwing)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 rotateDirection = player.transform.position - transform.position;
        rotateDirection.Normalize();
        rotationAngle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        rotationAngle -= 90;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        //Quaternion newQuaternion = Quaternion.Euler(0f, 0f, rotationAngle);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, newQuaternion, 60f * Time.deltaTime);
    }

    void Launch()
    {
        //audioSource.PlayOneShot(shootSound);
        Instantiate(bullet, obj.position - Vector2.up * 0.5f, Quaternion.Euler(0f, 0f, rotationAngle));
    }

    IEnumerator LaunchRocket()
    {
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

    public void Hitted()
    {
        //Instantiate(enemyEffect, obj.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}

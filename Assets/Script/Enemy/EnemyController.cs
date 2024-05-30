using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : Object
{
    public ParticleSystem explo;
    public bool isHoldItem;
    public List<GameObject> item;
    public List<Vector2> waypoints;
    public int currentWaypointIndex;
    public bool isControlling;
    public bool isFollwing;
    public float changeTime;
    public float moveTimer;
    int direction = 1;
    protected float rotationAngle = 0;

    protected Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (!isControlling)
        {
            moveTimer -= Time.deltaTime;
        }
        if (moveTimer < 0)
        {
            direction = -direction;
            moveTimer = changeTime;
        }
    }

    void FixedUpdate()
    {

        Vector2 newPosition = transform.position;
        newPosition.x = newPosition.x + Time.deltaTime * speed * direction;
        if (!isControlling)
        {
            transform.position = newPosition;
        }
        if (isFollwing)
        {
            RotateToPlayer();
        }
    }

    public void MoveWaypoint()
    {
        if (currentWaypointIndex >= waypoints.Count)
        {
            return;
        }
        Vector2 targetWaypoint = waypoints[currentWaypointIndex];
        StartCoroutine(MoveToNextWaypoint(targetWaypoint));
    }

    IEnumerator MoveToNextWaypoint(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 7f * Time.deltaTime);
            yield return null;
        }
        currentWaypointIndex++;

        if (currentWaypointIndex < waypoints.Count)
        {
            MoveWaypoint();
        }
        else
        {
            FreeMove();
        }
    }

    public void FreeMove()
    {
        isControlling = false;
    }

    protected void RotateToPlayer()
    {
        GameObject player = GameObject.Find("Player");
        Vector3 rotateDirection = player.transform.position - transform.position;
        rotateDirection.Normalize();
        rotationAngle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg;
        rotationAngle -= 90;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }

    void InstantiateItem()
    {
        int ramdomItem = Random.Range(0, 3);
        Instantiate(item[ramdomItem], transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layer = LayerMask.LayerToName(collision.gameObject.layer);
        if(layer == "PlayerBullet")
        {
            BulletController bulletController = collision.GetComponent<BulletController>();
            heart -= bulletController.damage;
            bulletController.Effect();
            if (!bulletController.isPlasma)
            {
                AudioController.instance.PlaySfx("enemyHitted1");
                Destroy(collision.gameObject);
            }
            else
            {
                AudioController.instance.PlaySfx("enemyHitted2");
            }
        }
        else if(layer == "Player")
        {
            if (explo != null)
            {
                Instantiate(explo, transform.position, Quaternion.identity);
            }
            if (isHoldItem)
            {
                InstantiateItem();
                isHoldItem = false;
            }
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }

        if(heart <= 0)
        {
            PlayerData.instance.ChangeDeadEnemy();
            if(explo != null)
            {
                Instantiate(explo, transform.position, Quaternion.identity);
            }
            if(isHoldItem)
            {
                InstantiateItem();
            }
            heart = 5;
            gameObject.SetActive(false);
        }
    }
}

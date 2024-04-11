using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowingBullet : MonoBehaviour
{
    public float speed;
    public int damage;
    float timer = 2f;

    private void Awake()
    {
        //GameObject player = GameObject.Find("Player");
        //Vector3 rotateDirection = player.transform.position - transform.position;
        //rotateDirection.Normalize();
        //float rotationAngle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg - 90;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }

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

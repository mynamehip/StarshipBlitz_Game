using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float heart;
    public float speed;
    float timer = 5f;
    public float zRotation;
    public float sizeScale;
    Vector3 targetDirection;

    private void Awake()
    {
        transform.localScale = new Vector3(sizeScale, sizeScale, sizeScale);
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        targetDirection = Quaternion.Euler(0f, 0f, -zRotation) * new Vector3(-1f, -1f, 0f);
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
            transform.Translate(targetDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject background;
    float repeatSize;
    bool isCreated = false;
    Vector2 newPosition;

    void Start()
    {
        repeatSize = GetComponent<BoxCollider2D>().size.y;
        newPosition = transform.position;
    }

    void Update()
    {
        //Vector2 currentPosition = transform.position;
        //Vector2 nextPosition = currentPosition;
        //nextPosition.y -= 0.1f;
        //transform.position = Vector2.Lerp(currentPosition, nextPosition, 0.1f);
        //if (currentPosition.y <= 0 && isCreated == false)
        //{
        //    isCreated = true;
        //    Vector2 spawnPosition = currentPosition;
        //    spawnPosition.y = spawnPosition.y + repeatSize / 2 - 0.01f;
        //    Instantiate(background, spawnPosition, Quaternion.identity);
        //}
        //if (-currentPosition.y > repeatSize / 2)
        //{
        //    Destroy(gameObject);
        //}
        newPosition.y = transform.position.y - 2f * Time.deltaTime;
        transform.position = newPosition;
        Vector3 spawnPosition = Vector3.zero - transform.position;
        spawnPosition.y += repeatSize - 0.25f;
        if (transform.position.y <= 0 && !isCreated)
        {
            Instantiate(background, spawnPosition, Quaternion.identity);
            isCreated = true;
        }
        if(transform.position.y < -repeatSize)
        {
            Destroy(gameObject);
        }
    }
}

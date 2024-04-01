using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : Object
{
    private Vector2 newPosition;
    float screenX;
    float screenY;

    private void Start()
    {
        newPosition = transform.position;
        GetScreenSize();
    }

    private void Update()
    {
        newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void GetScreenSize()
    {
        Vector2 screen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenX = screen.x;
        screenY = screen.y;
    }

    protected void Move()
    {
        newPosition.x = Mathf.Clamp(newPosition.x, -screenX, screenX);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenY, screenY);
        if ((Vector2)transform.position != newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        }
    }

    //protected void Turn()
    //{
    //    Vector3 rotateDirection = targetPosition - (Vector2)transform.position;
    //    rotateDirection.Normalize();
    //    float rotationAngle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg - 90;
    //    transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    //}
}

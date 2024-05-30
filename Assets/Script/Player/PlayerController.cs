using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Object
{
    public ParticleSystem explo;
    public GameController gc;
    public Image heartBar;
    SpriteRenderer spriteRenderer;
    private Vector2 direction;
    float screenX;
    float screenY;

    private Vector3 touchPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = PlayerData.instance.GetSkin();
        GetScreenSize();
    }

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0f;
                    break;

                case TouchPhase.Moved:
                    Vector3 deltaPosition = Camera.main.ScreenToWorldPoint(touch.position) - touchPosition;
                    Vector2 newPosition = (Vector2)transform.position + (Vector2)deltaPosition;
                    newPosition.x = Mathf.Clamp(newPosition.x, -screenX, screenX);
                    newPosition.y = Mathf.Clamp(newPosition.y, -screenY, screenY);
                    rb.MovePosition(newPosition);
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0f;
                    break;
            }
        }

    }

    public void GetScreenSize()
    {
        Vector2 screen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenX = screen.x;
        screenY = screen.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layer = LayerMask.LayerToName(collision.gameObject.layer);
        if (layer == "EnemyBullet")
        {
            EnemyBulletController bulletController = collision.GetComponent<EnemyBulletController>();
            heart -= bulletController.damage;
            ChangeHeart();
            bulletController.Effect();
            Destroy(collision.gameObject);
        }
        else if (layer == "Enemy")
        {
            gc.DeadPlayer();
            heart = 0;
            ChangeHeart();
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }

        if (heart <= 0)
        {
            gc.DeadPlayer();
            ChangeHeart();
            if(explo != null)
            {
                Instantiate(explo, transform.position, Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
    }

    void ChangeHeart()
    {
        heartBar.fillAmount = (float)heart / 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}

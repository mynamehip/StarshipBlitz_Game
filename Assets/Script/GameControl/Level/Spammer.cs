using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spammer : MonoBehaviour
{
    public GameObject o;
    public GameController gc;
    public Sprite star;
    AsteroidController ac;
    float position;
    int zRotation;
    int speed;
    float size;
    float timer = 1f;
    public float stopTime;

    int check = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if(stopTime > 0)
        {
            stopTime -= Time.deltaTime;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SpawmObject();
                timer = Random.Range(0.1f, 0.2f);
            }
        }
        else
        {
            stopTime -= Time.deltaTime ;
            if(stopTime <= -3 && check == 0)
            {
                gc.Win();
                check++;
            }
        }
    }

    void SpawmObject()
    {
        position = Random.Range(-8f, 20f);
        Instantiate(o, new Vector2(position, 6.5f), Quaternion.identity);
        zRotation = Random.Range(0, 180);
        speed = Random.Range(3, 5);
        size = Random.Range(0.5f, 2);
        ac = o.GetComponent<AsteroidController>();
        ac.speed = speed;
        ac.sizeScale = size;
        ac.zRotation = zRotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : TackleEnemy
{
    bool tackled = false;

    void Start()
    {
        AudioController.instance.PlaySfx("enemyTackle1");
    }

    new void Update()
    {
        if (!isControlling)
        {
            tackleTimer -= Time.deltaTime;
        }
        if (!tackled)
        {
            transform.Translate(Vector3.up * 5f * Time.deltaTime);
        }
        if (tackleTimer <= 0)
        {
            tackled = true;
            StartCoroutine(Tackle());
            tackleTimer = 30f;
        }
    }
}

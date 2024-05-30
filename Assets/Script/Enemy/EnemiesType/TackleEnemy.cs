using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackleEnemy : EnemyController
{
    public float tackleTimer;

    void Start()
    {
        if (tackleTimer <= 0)
        {
            tackleTimer = Random.Range(5f, 20f);
        }
    }

    
    new void Update()
    {
        base.Update();
        if (!isControlling)
        {
            tackleTimer -= Time.deltaTime;
        }
        if(tackleTimer <= 0)
        {
            StartCoroutine(Tackle());
            tackleTimer = 30f;
        }
    }

    protected IEnumerator Tackle()
    {
        AudioController.instance.PlaySfx("enemyTackle1");
        RotateToPlayer();
        float liveTime = 5f;
        while (liveTime >= 0)
        {
            transform.Translate(Vector3.up * 5f * Time.deltaTime);
            liveTime -= Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}

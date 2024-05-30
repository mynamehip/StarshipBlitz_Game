using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveGroup : MonoBehaviour
{
    public Vector2 targetPosition;
    public float speed;
    Transform parentTransform;

    void Start()
    {
        parentTransform = gameObject.transform;
        StartCoroutine(MoveToPosition(targetPosition));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        while ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        FreeChildMove();
    }

    void FreeChildMove()
    {
        for(int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i);
            EnemyController childObject = childTransform.gameObject.GetComponent<EnemyController>();
            childObject.FreeMove();
        }
    }
}

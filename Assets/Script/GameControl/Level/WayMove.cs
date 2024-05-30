using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromLeft : MonoBehaviour
{
    public List<EnemyController> enemyList = new List<EnemyController>();
    public List<Vector2> positions = new List<Vector2>();

    void Start()
    {
        MoveEnemy(positions);
    }

    void MoveEnemy(List<Vector2> targetPosition)
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            for (int j = targetPosition.Count - 1; j >= i; j--)
            {
                enemyList[i].waypoints.Add(targetPosition[j]);
            }
            enemyList[i].MoveWaypoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

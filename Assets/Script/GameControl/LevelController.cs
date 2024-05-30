using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int rowNumber;
    //public GameObject enemy;
    //EnemyController enemyControl;

    //GameObject player;
    //PlayerController player_Control;
    //Vector3 playerPosition;

    //float timer = 0f;
    //public int enemyNumber = 10;
    //public List<Vector2> chosenPosition = new List<Vector2>();

    void Start()
    {
        //player = GameObject.Find("Player");
        //if (player != null)
        //{
        //    player_Control = player.GetComponent<PlayerController>();
        //}
    }
    private void Update()
    {
    }

    //void SpawnEnemy()
    //{
    //    GameObject enemyObj = Instantiate(enemy, transform.position, Quaternion.identity);
    //    enemyControl = enemyObj.GetComponent<Enemy_Control>();
    //    enemyList.Add(enemyControl);
    //    timer = 0.5f;
    //    enemyNumber--;
    //    enemyControl.isControlled = true;
    //    enemyControl.isAimAttack = true;
    //    enemyControl.numberTargetPosition = 0;
    //    if (chosenPosition.Count == 1)
    //    {
    //        if (enemyNumber <= 8)
    //        {
    //            MoveToLastPosition(0);
    //        }
    //    }
    //    enemyControl.chosenPosition = chosenPosition[0];
    //}

    //void Rotate()
    //{
    //    for (int i = 0; i < enemyList.Count; i++)
    //    {
    //        enemyList[i].playerPosition = playerPosition;
    //    }
    //}

    //void EnemyMove()
    //{
    //    for (int i = 0; i < enemyList.Count; i++)
    //    {
    //        if (enemyList[i].numberTargetPosition < chosenPosition.Count - 1)
    //        {
    //            if (enemyList[i].currentPosition == chosenPosition[enemyList[i].numberTargetPosition])
    //            {
    //                enemyList[i].numberTargetPosition++;
    //                if (enemyList[i].numberTargetPosition == chosenPosition.Count - 1)
    //                {
    //                    if (i > 0)
    //                    {
    //                        MoveToLastPosition(enemyList[i].numberTargetPosition);
    //                        enemyList[i].chosenPosition = chosenPosition[enemyList[i].numberTargetPosition];
    //                    }
    //                    else
    //                    {
    //                        enemyList[i].chosenPosition = chosenPosition[enemyList[i].numberTargetPosition];
    //                    }
    //                }
    //                else
    //                {
    //                    enemyList[i].chosenPosition = chosenPosition[enemyList[i].numberTargetPosition];
    //                }
    //            }
    //        }
    //    }
    //}

    //void MoveToLastPosition(int i)
    //{
    //    float x = chosenPosition[i].x + 1.5f;
    //    float y = chosenPosition[i].y;
    //    chosenPosition[i] = new Vector2(x, y);
    //}
}

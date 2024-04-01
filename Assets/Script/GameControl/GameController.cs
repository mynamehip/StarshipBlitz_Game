using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool isPausing = false;

    private void Awake()
    {
        Cursor.visible = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPausing)
            {
                isPausing = true;
            }
            else
            {
                isPausing = false;
            }
        }
        if(isPausing )
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scence : MonoBehaviour
{
    public List<GameObject> scences = new List<GameObject>();

    public List<GameObject> GetScence()
    {
        return scences;
    }
}

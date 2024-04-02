using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfterTime : MonoBehaviour
{
    public float time = 5;
    private void Awake()
    {
        Destroy(gameObject, time);
    }
}

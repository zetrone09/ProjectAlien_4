using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodvfx : MonoBehaviour
{
    private float timeToDestroy = 2f;
    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
}

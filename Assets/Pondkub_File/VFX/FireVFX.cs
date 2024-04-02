using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireVFX : MonoBehaviour
{
    private float TimeDestroy;
    void Update()
    {
        Destroy(gameObject, 3f);
    }
}

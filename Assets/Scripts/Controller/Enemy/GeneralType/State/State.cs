using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    // base class 
    public virtual State Tick(GeneralTypeManager generalTypeManager)
    {
        return this;
    }
}

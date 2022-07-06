using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachTransition : Transition
{
    public void NextState(Transform target)
    {
        NeedTransit = true;
    }
}

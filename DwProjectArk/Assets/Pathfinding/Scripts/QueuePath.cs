using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class QueuePath 
{
    public Vector3 startPos;
    public Vector3 endPos;
    public Action<List<Vector3>> storeRef;

    public QueuePath(Vector3 sPos, Vector3 ePos, Action<List<Vector3>> theRefMethod)
    {
        startPos = sPos;
        endPos = ePos;
        storeRef = theRefMethod;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMomentumObject : MonoBehaviour
{
    public static FinalMomentumObject instance;
    void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }
    public Transform finishPoint,shootPoint;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstical : MonoBehaviour
{
    public bool isPosOne;
    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}

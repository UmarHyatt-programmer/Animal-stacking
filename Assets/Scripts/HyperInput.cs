using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperInput : MonoBehaviour
{
    float mouseX;
    public float detlaX;
    public float moveFactor=>detlaX;
    void Update()
    {
      //  mulist.Add(1);
        if (Input.GetMouseButtonDown(0))
        {
            mouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            detlaX = Input.mousePosition.x - mouseX;
            mouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            detlaX = 0f;
        }
    }
}

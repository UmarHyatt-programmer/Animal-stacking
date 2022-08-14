using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Net;

public class RunnerObject : MonoBehaviour
{
    public UnityEvent OnCatch;
    public float runSpeedMin,runSpeedMax,runSpeed;
    public bool isRun=true;
    public bool isCatch=false;
       class Runner
       {
        public string name;
        public int age;
       }
       Runner runner;
    private void Start() {
       // HttpWebRequest.Create("https:www.ommygames.com");
       var obj=JsonUtility.ToJson(runner);
       UnityWebRequest.Post("slkfdjasdljflasd",obj);
        runSpeed=Random.Range(runSpeedMin,runSpeedMax);
    }
    private void FixedUpdate()
    {
        if (isRun)
        {
            if(!isCatch&&transform.position.z>=FinalMomentumObject.instance.finishPoint.position.z)
            {
                if(transform.eulerAngles.y==0)
                {
                   transform.rotation=Quaternion.Euler(Vector3.up*90);
                   transform.Translate(transform.forward * runSpeed * Time.fixedDeltaTime);
                }
                //return;
            }
            transform.Translate(transform.forward * runSpeed * Time.fixedDeltaTime);
        }
    }
}

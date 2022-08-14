using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public AnimationCurve inrementalCurve;
    public AnimationCurve powerCurve;
    public GameObject[] objPrefab;
    public GameObject[] powerPrefab;
    public float yPos;
    public float zDistanceMin, zDistanceMax;
    public float xDistanceMin, xDistanceMax;
    public float LevelNo;
    public void Start()
    {
        int noOfObjects = (int)inrementalCurve.Evaluate(LevelNo);
        for (int i = 0; i < noOfObjects; i++)
        {
            Instantiate(objPrefab[Random.Range(0, objPrefab.Length)], new Vector3(Random.Range(xDistanceMin, xDistanceMax), yPos, Random.Range(zDistanceMin, zDistanceMax)), Quaternion.identity);
        }
    }
    public void SpawnPower(float minZ, float maxZ)
    {
        int noOfPower = (int)powerCurve.Evaluate(LevelNo);
        for (int i = 0; i < noOfPower; i++)
        {
            Instantiate(powerPrefab[Random.Range(0, powerPrefab.Length)], new Vector3(Random.Range(xDistanceMin, xDistanceMax),0.5f , Random.Range(minZ, maxZ)), Quaternion.identity);
        }
    }
}

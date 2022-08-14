using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreater : MonoBehaviour
{
    public AnimationCurve difficultyCurve;
    public GameObject finalMomentumPrefab;
    public GameObject[] PathPrefabs;
    public float zDistance;
    public float LevelNo;
    public List<GameObject> paths=new List<GameObject>();
    private void Start()
    {
        //int pathLenght=(int)difficultyCurve.Evaluate(PlayerPrefs.GetInt("Levelno"));
        float incrementDistance=0;
        int pathLenght=(int)difficultyCurve.Evaluate(LevelNo);
        for (int i = 0; i < pathLenght; i++)
        {
            paths.Add(Instantiate(PathPrefabs[Random.Range(0,PathPrefabs.Length)],new Vector3(0,0,incrementDistance),Quaternion.identity));
            incrementDistance+=zDistance;
        }
            paths.Add(Instantiate(finalMomentumPrefab,new Vector3(0,0,incrementDistance),Quaternion.identity));
        ObjectSpawner.instance.SpawnPower(-360,paths[paths.Count-1].transform.localPosition.z+zDistance);
    }
}

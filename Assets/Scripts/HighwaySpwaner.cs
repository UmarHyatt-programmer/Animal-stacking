using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwaySpwaner : MonoBehaviour
{ public static HighwaySpwaner instace; void Awake() { if (instace == null) instace = this; }

   
    public GameObject[] highWays ;
    public int numbersOfLines;
    int pos1, pos2;
    int[] PositionSet = { -10, -8, -6, -4, -2, 0, 2, 4, 6, 8, 10 };
    public GameObject obsticalPrefab, powerPrefab;
    int DifferentInLines = 10;
    public int DifferentInLines2;
    public Score _score;
    void Start()
    {
        SpawnObjects();
    }
    public void SpawnObjects()
    {
        // for obticals spawn
        for (int i = 0; i < numbersOfLines; i++)
        {
          
            pos2 = Random.Range(0, 11);
            
            Instantiate(obsticalPrefab, new Vector3(PositionSet[pos1], 1, DifferentInLines), new Quaternion());
            //   objt.GetComponent<Obstical>().isPosOne=true;
            // obsticals.Add(objt);

            Instantiate(obsticalPrefab, new Vector3(PositionSet[pos2], 1, DifferentInLines), new Quaternion());
            DifferentInLines += DifferentInLines2;
        }
        // for energy spawn
        for (int i = 0; i < numbersOfLines; i++)
        {
            pos1 = Random.Range(0, 11);
            pos2 = Random.Range(0, 11);
            while (pos2 == pos1)
            {
                pos2 = Random.Range(0, 11);
            }
            Instantiate(powerPrefab, new Vector3(PositionSet[pos1], 1, DifferentInLines), new Quaternion());
            Instantiate(powerPrefab, new Vector3(PositionSet[pos2], 1, DifferentInLines), new Quaternion());
            DifferentInLines += DifferentInLines2;
        }
    }
    // public void CreateNewObject(bool posOne)
    // {
    //     if(posOne)
    //     {
    //     powers.Add(Instantiate(obsticalPrefab, new Vector3(PositionSet[pos1], 1,_score.posZ+10), Quaternion.identity));
    //     print("print");
    //     }
    //     else
    //     {
    //     print("print2");
    //     powers.Add(Instantiate(obsticalPrefab, new Vector3(PositionSet[pos2], 1,_score.posZ+10), new Quaternion()));
    //     }
    // }
    bool isUpated = false;
    public int currentUpdate = 1;
    public int increamentValue;
    private void Update()
    {

        if (_score.posZ > increamentValue * currentUpdate)
        {
            if (!isUpated)
            {
                isUpated = true;
                currentUpdate++;
                numbersOfLines += 5;
                SpawnObjects();
            }
            isUpated = false;
        }
        // numbersOfLines+=(int)_score.posZ/DifferentInLines;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Presionar : MonoBehaviour
{
    public GameObject prefab;
    public int numOfSuccess = 0, numOfFailed = 0, finalSuccess = 0, finalFailed = 0;
    public Hashtable numberHash;
    public Transform parent;
    public List<int> AI = new List<int>();
    public int number;
    public List<int> hundNumbers = new List<int>();
    GameObject outer;
    public List<GameObject> outerList = new List<GameObject>();
    public bool heehe = false;
    private void Update()
    {
        if (heehe)
        {
            hundNumbers.Clear();
            for (int i = 0; i < 100; i++)
            {
                //  outerList[i].gameObject.SetActive(false);
                Destroy(outerList[i].gameObject);
            }
            outerList.Clear();
        }
        heehe = true;
        Startt();


    }
    private void Startt()
    {
        AINumber();
        for (int i = 1; i <= 100; i++)
        {
            hundNumbers.Add(i);
        }
        for (int i = 1; i <= 100; i++)
        {
            outer = Instantiate(prefab, parent);
            outerList.Add(outer);
            outer.transform.GetChild(0).GetComponent<Text>().text = i.ToString();

            // outer.transform.GetChild(1).gameObject.SetActive(true);

            outer.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = RandDiffNumber().ToString();
        }

        AIResult();


    }
    public int RandDiffNumber()
    {
        int randomIndex = Random.Range(0, hundNumbers.Count);
        int randomNumber = hundNumbers[randomIndex];
        hundNumbers.Remove(randomNumber);
        return randomNumber;
    }
    public void AINumber()
    {
        for (int i = 1; i <= 100; i++)
        {
            AI.Add(i);
        }

    }
    public GameObject childFalse;
    public void AIResult()
    {
        // int AI[0] = 1;
        int checkText = AI[0];


        int outerindex = 0;
        string log = "result empty";

        for (int n = 0; n < 100; n++)
        {
            print("AI[0] index = " + AI[n]);
            checkText = AI[n];

            for (int i = 1; i <= 50; i++)
            {
                print("Number of loop" + i);
                outerindex = 0;
                print("outer text" + checkText);
                while (checkText != int.Parse(outerList[outerindex].transform.GetChild(0).GetComponent<Text>().text))
                {
                    print("Hey outer was not set! hmm i set it" + outerList[outerindex].transform.GetChild(0).GetComponent<Text>().text);
                    outerindex++;
                }
                //outerList[outerindex]
                checkText = int.Parse(outerList[outerindex].transform.GetChild(1).GetChild(0).GetComponent<Text>().text);

                print("inner text" + checkText);
                outerList[outerindex].transform.GetChild(1).gameObject.SetActive(true);

                if (AI[n] == checkText)
                {

                    print("Yes! is find" + checkText);
                    numOfSuccess++;
                    log = "success";
                    break;
                }
                if (i == 5)
                {
                    numOfFailed++;
                    log = "failed";
                }
            }
            print(log);
        }
        print("Total Success" + numOfSuccess);
        print("Total Failed" + numOfFailed);
        print("Succes percrent age Persentage" + numOfSuccess * 100 / (numOfSuccess + numOfFailed));

    }



}

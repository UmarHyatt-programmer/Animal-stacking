using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject obj;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                obj = new GameObject("MyOBject");
            instance = new GameObject("GameManager").AddComponent<GameManager>(); //create game manager object if required
            return instance;

        }
    }
    public void myFunction<T>()
    {

    }
    private static GameManager instance = null;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject); //Delete duplicate
        }
        else
        {
            instance = this; //Make this object the only instance
            DontDestroyOnLoad(gameObject); //Set as do not destroy

            if (!PlayerPrefs.HasKey("LevelNo"))
            {
                PlayerPrefs.SetInt("LevelNo", 1);
            }
            if(!PlayerPrefs.HasKey("Sound"))
            {
                PlayerPrefs.SetInt("Sound",1);
            }
            // if (!PlayerPrefs.HasKey("ColorAssign"))
            // {
            //     PlayerPrefs.SetInt("ColorAssign", 1);
            // }
            // if (!PlayerPrefs.HasKey("GameComplete"))
            // {
            //     PlayerPrefs.SetInt("GameComplete", 0);
            // }
        }
    }
    public void SoundONOFF()
    {
        if(PlayerPrefs.GetInt("Sound")==0)
        {
            PlayerPrefs.SetInt("Sound",1);
            SoundManager.instance.isSound=true;
        }
        else
        {
            PlayerPrefs.SetInt("Sound",0);
            SoundManager.instance.isSound=false;
        }
    }
}

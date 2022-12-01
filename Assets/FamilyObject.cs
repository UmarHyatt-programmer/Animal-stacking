using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FamilyObject : MonoBehaviour
{
    public int gems = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            other.gameObject.SetActive(false);
            gems++;
            UiManager.instance.gemPrefab.gameObject.SetActive(true);
            UiManager.instance.gemsTxt.text = gems.ToString();
        }
        MyFormData OBJ = new MyFormData();
        var o = OBJ;
        string myJson = JsonUtility.ToJson(OBJ);
        UnityWebRequest.Post("httafsdfpsdfasdfsdaf", myJson);
    }
}
public class MyFormData
{
    public string email;
    public string password;
}
public class myClass
{

}

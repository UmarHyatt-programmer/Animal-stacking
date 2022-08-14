using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class AbilityObject : MonoBehaviour, IAbility
{
    public float rotateSpeed = 10;
    public Vector3 rotateDirection;
    public void Update()
    {
        transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }
    public void Power()
    {
        StackPlayer.instance.StartCoroutine(StackPlayer.instance.PowerUp());
        this.gameObject.SetActive(false);
    }
}

public interface IAbility
{
    public void Power();
}

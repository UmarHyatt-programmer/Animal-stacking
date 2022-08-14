using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeshAndAnimation : MonoBehaviour
{
    public Mesh[] playerSkins;
    public PlayerPrefs playerAvatar;
    public  int avatar=0;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("playerAvatar", avatar);
        // playerSkins[PlayerPrefs.GetInt("playerAvatar")];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

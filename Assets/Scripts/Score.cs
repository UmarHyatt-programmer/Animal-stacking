using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public Transform player;
    public Text ScoreText, highScoretxt;
    // Update is called once per frame
    public float posZ;
    private void Start()
    {
        highScoretxt.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    void Update()
    {
        posZ = (player.position.z + 190) / 10;
        ScoreText.text = posZ.ToString("0");
    }
    public void UpdateHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < posZ)
        {
            PlayerPrefs.SetInt("HighScore", (int)posZ);
        }
    }
}

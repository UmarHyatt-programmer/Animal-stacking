using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    #region singleton
    public static UiManager instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;

        }
    }
    #endregion
    public GameObject settingPnl,playButton;
    public Text coinsTxt,gemsTxt;
    public Transform gemPrefab;
    public Transform gemStartPoint,gemPoint;
    private void Start() {
        Time.timeScale=0;
    }
    public void SettingButton()
    {
        if (settingPnl.activeInHierarchy)
        {
            settingPnl.SetActive(false);
        }
        else
        {
            settingPnl.SetActive(true);
        }
    }
    private void Update() 
    {
        if(gemPrefab.gameObject.activeInHierarchy)
        {
            if(gemPrefab.position.x==gemPoint.position.x)
            {
                gemPrefab.position=gemStartPoint.position;
                gemPrefab.gameObject.SetActive(false);
            }
            gemPrefab.position=Vector3.MoveTowards(gemPrefab.position,gemPoint.position,10);
        }
    }
    public void StartButton()
    {
        playButton.SetActive(false);
        Time.timeScale=1;
    }
    public void SoundButton()
    {
        GameManager.Instance.SoundONOFF();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}